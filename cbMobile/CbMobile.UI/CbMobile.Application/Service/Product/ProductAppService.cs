using CbMobile.Application;
using CbMobile.Database;
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
        public IEnumerable<ProductViewModel> GetProduct()
        {
            var model = _dbContext.Products
                .Where(x => x.Hot == true && x.Status == true)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    AvatarUrl = x.AvatarUrl,
                    Value = x.Value,
                })
                .ToList();
            return model;
        }
        public IEnumerable<CategoryProductViewModel> GetPhoneProductInHome()
        {
            var model = _dbContext.CategoryProducts
                .Include(x => x.Products)
                .Where(x => x.Id == (int)CategoryProductType.SmartPhone)
                .Select(x => new CategoryProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = x.Products.Select(y => new ProductViewModel
                    {
                        Id = y.Id,
                        Name = y.Name,
                        ShortDescription = y.ShortDescription,
                        AvatarUrl = y.AvatarUrl,
                        FullDescription = y.FullDescription,
                        Value = y.Value
                    })
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
                    AvatarUrl = model.AvatarUrl,
                    FullDescription = model.FullDescription,
                    CategoryProductId = model.CategoryProductId,
                    ManufacturerId = model.ManufacturerId,
                };
            }
            throw new KeyNotFoundException();
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
                     Value = x.Value
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
                     Value = x.Value
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
    }
}
