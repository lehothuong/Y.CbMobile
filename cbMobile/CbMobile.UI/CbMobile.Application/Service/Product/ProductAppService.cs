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
        public IEnumerable<ManufacturerViewModel> GetProduct()
        {
            var model = _dbContext.Manufacturers
                .Include(x => x.Products)
                .Select(x => new ManufacturerViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = x.Products.Select(y => new ProductViewModel
                    {
                        Name = y.Name,
                        ShortDescription = y.ShortDescription,
                        AvatarUrl = y.AvatarUrl,
                        FullDescription = y.FullDescription
                    })
                })
                .ToList();
            return model;
        }
    }
}
