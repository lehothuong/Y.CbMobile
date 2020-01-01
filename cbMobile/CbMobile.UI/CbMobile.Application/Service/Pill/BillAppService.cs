using CbMobile.Database;
using CbMobile.Domain;
using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobile.Application.Service
{
    public class BillAppService : IBillAppService
    {
        private ApplicationDbContext _dbContext;
        public BillAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region Admin
        public Object AdminGetAllBill(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
               .Bill
               .Where(x => !x.Deleted)
               .AsNoTracking()
               .OrderBy(x => x.DisplayOrder)
               .ThenByDescending(x => x.CreatedDate);
            var totalCount = model.Count();
            var results = model
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new
            {
                totalCount = totalCount,
                data = results
            };
        }
        public Bill GetDetailsBill(int id)
        {
            var model = _dbContext
                .Bill
                .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool DeleteBill(int id)
        {
            var model = _dbContext
                 .Bill
                 .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                model.Deleted = true;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
      
        public bool IsCheckPayment(int id, bool isPay)
        {
            var model = _dbContext
                         .Bill
                         .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                model.IsPay = isPay;
                _dbContext.SaveChanges();
                return model.IsPay;
            }
            return false;
        }
        public List<DetailBillViewModel> GetDetailBillById(int id)
        {
            var model = _dbContext
                         .DetailBill
                         .Where(x => x.BillId == id)
                         .Select(x => new DetailBillViewModel
                         {
                             ProductName = x.Product.Name,
                             ColorName = x.ColorName,
                             MemoryName = x.MemoryName,
                             Amount = x.Amount,
                             Price = x.Price,
                             TotalPrice = x.TotalPrice
                         })
                         .ToList();
            return model;
        }
        #endregion
        #region UI
        public bool PostOrder(OrderViewModel order)
        {
            if (order != null)
            {
                var bill = new Bill();
                bill.Email = order.Email;
                bill.UserName = order.UserName;
                bill.Address = order.Address;
                bill.PhoneNumber = order.PhoneNumber;
                bill.Payment = order.Payment;
                bill.Content = order.Content;
                bill.TotalBill = GetSumTotalBill(order.Cart);
                _dbContext.Bill.Add(bill);
                _dbContext.SaveChanges();
                var orders = new List<DetailBill>();
                foreach (var item in order.Cart)
                {
                    orders.Add(new DetailBill
                    {
                        ProductId = item.ProductId,
                        BillId = bill.Id,
                        Amount = item.Amount,
                        ColorName = item.mainColorName,
                        MemoryName = item.mainMemoryName,
                        Price = GetValueByProductId(item.ProductId, item.MainColorId, item.MainMemoryId),
                        TotalPrice = item.Amount * GetValueByProductId(item.ProductId, item.MainColorId, item.MainMemoryId)
                    });
                }
                _dbContext.DetailBill.AddRange(orders);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public string GetSumTotalBill(List<DetailOrderViewModel> cart)
        {
            decimal price = 0;
            foreach(var item in cart)
            {
                price += item.Amount * GetValueByProductId(item.ProductId, item.MainColorId, item.MainMemoryId);
            }
            return price.ToString();
        }
        public decimal GetValueByProductId(int productId, int mainColorId, int mainMemoryId)
        {
            var model = _dbContext
                        .Products
                        .Where(x => x.Id == productId)
                        .FirstOrDefault();
            if (model.ValuePromotion != null)
            {
                return model.ValuePromotion.Value;
            }
            return 0;
        }
        #endregion

    }
}
