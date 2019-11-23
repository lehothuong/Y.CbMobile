using CbMobile.Application;
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
    public class ProductAppService : IProductAppService
    {
        private ApplicationDbContext _dbContext;
        public ProductAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region Admin
        public Object GetAllProduct(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
                .Products
                .AsNoTracking()
                .Where(x => !x.Deleted)
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.CreatedDate)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    DisplayOrder = x.DisplayOrder,
                    CreatedDate = x.CreatedDate,
                    Hot = x.Hot,
                });
            var totalCount = model.Count();
            var results = model
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize).ToList();
            return new
            {
                totalCount = totalCount,
                data = results
            };
        }
        public Product GetDetailsProduct(int id)
        {
            var model = _dbContext
                  .Products
                  .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public List<int> GetArrListMemory(string strListMemoryId)
        {
            if (string.IsNullOrEmpty(strListMemoryId))
            {
                return new List<int> { };
            }
            var listId = strListMemoryId.Split(",").Select(x => int.Parse(x)).ToList();
            return _dbContext
                        .MainMemorys
                        .GetPublished()
                        .Where(x => listId.Contains(x.Id))
                        .Select(x => x.Id)
                        .ToList();
        }
        public bool CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateProduct(Product product)
        {
            var model = _dbContext
                 .Products
                 .FirstOrDefault(x => x.Id == product.Id);
            if(model != null)
            {
                model.Name = product.Name;
                model.DisplayOrder = product.DisplayOrder;
                model.AvatarUrl = product.AvatarUrl;
                model.UpdatedDate = product.UpdatedDate;
                model.Status = product.Status;
                model.ShortDescription = product.ShortDescription;
                model.FullDescription = product.FullDescription;
                model.Hot = product.Hot;
                model.Value = product.Value;
                model.ValuePromotion = product.ValuePromotion;
                model.Published = product.Published;
                model.MainMemory = product.MainMemory;
                model.CategoryProductId = product.CategoryProductId;
                model.ManufacturerId = product.ManufacturerId;

                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteProduct(int id)
        {
            var model = _dbContext
                 .Products
                 .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                model.Deleted = true;
                model.Published = false;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion
        #region UI
        public IEnumerable<ProductViewModel> GetProduct()
        {
            var model = _dbContext
                .Products
                .AsNoTracking()
                .GetPublished()
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.CreatedDate)
                .Take(6)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    AvatarUrl = x.AvatarUrl,
                    ValuePromotion = x.ValuePromotion
                })
                .ToList();
            return model;
        }
        public IEnumerable<ProductViewModel> GetPhoneProductInHome()
        {
            var model = _dbContext.Products
                .AsNoTracking()
                .GetPublished()
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.CreatedDate)
                .Where(x => x.CategoryProductId == (int)CategoryProductType.SmartPhone)
                .Take(10)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    AvatarUrl = x.AvatarUrl,
                    ValuePromotion = x.ValuePromotion
                })
                .ToList();
            return model;
        }
        public ProductViewModel GetDetails(int id)
        {
            var model = _dbContext
                .Products
                .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return new ProductViewModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Value = model.Value,
                    ValuePromotion = model.ValuePromotion,
                    AvatarUrl = model.AvatarUrl,
                    FullDescription = model.FullDescription,
                    CategoryProductId = model.CategoryProductId,
                    ManufacturerId = model.ManufacturerId,
                    Status = model.Status,
                    ListMemory = GetStringMainMemory(model.ListMemory),
                };
            }
            throw new KeyNotFoundException();
        }
        public object GetStringMainMemory(List<int> listMainMemory)
        {
            return _dbContext.MainMemorys
                     .Where(x => listMainMemory
                     .Contains(x.Id))
                     .Select(x => new
                     {
                         Id = x.Id,
                         Name = x.Name
                     })
                     .ToList();
        }
        public IEnumerable<ProductViewModel> GetGenericProduct(int id)
        {
            var model = _dbContext
                 .Products
                 .Where(x => x.CategoryProductId == id)
                 .Select(x => new ProductViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     ShortDescription = x.ShortDescription,
                     AvatarUrl = x.AvatarUrl,
                     FullDescription = x.FullDescription,
                     Value = x.Value,
                     ValuePromotion = x.ValuePromotion
                 })
                 .ToList();
            return model;
        }
        public IEnumerable<ProductViewModel> GetIndexProductById(int id)
        {
            var model = _dbContext
                 .Products
                 .Include(x => x.CategoryProduct)
                 .Where(x => x.CategoryProductId == id)
                 .Select(x => new ProductViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     ShortDescription = x.ShortDescription,
                     AvatarUrl = x.AvatarUrl,
                     FullDescription = x.FullDescription,
                     Value = x.Value,
                     ValuePromotion = x.ValuePromotion,
                 })
                 .ToList();
            return model;
        }
        public IEnumerable<ProductViewModel> GetIndexManufactureById(int id, int idCategory)
        {
            var model = _dbContext
                 .Products
                 .Include(x => x.CategoryProduct)
                 .Where(x => x.ManufacturerId == id && x.CategoryProductId == idCategory)
                 .Select(x => new ProductViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     ShortDescription = x.ShortDescription,
                     AvatarUrl = x.AvatarUrl,
                     FullDescription = x.FullDescription,
                     Value = x.Value
                 })
                 .ToList();
            return model;
        }
        #endregion
    }
}
