using CbMobile.Database;
using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CbMobile.Application.Service
{
    public class CategoryProductAppService : ICategoryProductAppService
    {
        private ApplicationDbContext _dbContext;
        public CategoryProductAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Object GetAllCategory(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
                  .CategoryProducts
                  .GetPublished()
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
        public Object GetListDropdownCategoryProduct()
        {
            return _dbContext
                  .CategoryProducts
                  .AsNoTracking()
                  .GetPublished()
                  .OrderBy(x => x.DisplayOrder)
                  .ThenByDescending(x => x.CreatedDate)
                  .Select(x => new
                  {
                      Id = x.Id,
                      Name = x.Name
                  })
                  .ToList();
        }
        public CategoryProduct GetDetailsCategoryProduct(int id)
        {
            var model = _dbContext
                  .CategoryProducts
                  .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool CreateCategoryProduct(CategoryProduct categoryProduct)
        {
            _dbContext.CategoryProducts.Add(categoryProduct);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateCategoryProduct(CategoryProduct categoryProduct)
        {
            var model = _dbContext
                 .CategoryProducts
                 .FirstOrDefault(x => x.Id == categoryProduct.Id);
            if (model != null)
            {
                model.Name = categoryProduct.Name;
                model.DisplayOrder = categoryProduct.DisplayOrder;
                model.UpdatedDate = categoryProduct.UpdatedDate;
                model.Published = categoryProduct.Published;

                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
        public bool DeleteCategoryProduct(int id)
        {
            var model = _dbContext
                 .CategoryProducts
                 .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                model.Deleted = true;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<CategoryProductViewModel> GetMenuCategory()
        {
            var model = _dbContext
                  .CategoryProducts
                  .Include(x => x.OrderManuFacturers)
                  .Select(x => new CategoryProductViewModel
                  {
                      Id = x.Id,
                      Name = x.Name,
                      OrderManufacturers = x.OrderManuFacturers.Select(y => new OrderManufacturerViewModel
                      {
                          ManufacturerID = y.ManufacturerID,
                          Manufacturers = y.Manufacturers
                      })
                  })
                  .ToList();
            return model;
        }
        public CategoryProductViewModel GetCategoryProductById(int id)
        {
            var model = _dbContext
                 .CategoryProducts
                 .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return new CategoryProductViewModel()
                {
                    Name = model.Name,
                };
            }
            throw new KeyNotFoundException();
        }
    }
}
