using CbMobile.Application;
using CbMobile.Database;
using CbMobile.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobileApplication.Service.Product
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
    }
}
