using CbMobile.Database;
using CbMobile.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobile.Application.Service.CategoryProduct
{
    public class CategoryProductAppService : ICategoryProductAppService
    {
        private ApplicationDbContext _dbContext;
        public CategoryProductAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
                      OrderManufacturers = x.OrderManuFacturers.Select(y => new OrderManufacturerViewModel {
                          ManufacturerID = y.ManufacturerID,
                          Manufacturers = y.Manufacturers
                      })
                  })
                  .ToList();
            return model;
        }
    }
}
