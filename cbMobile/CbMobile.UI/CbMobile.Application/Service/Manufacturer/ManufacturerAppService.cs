using CbMobile.Database;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobile.Application.Service.Manufacturer
{
    public class ManufacturerAppService : IManufacturerAppService
    {
        private ApplicationDbContext _dbContext;
        public ManufacturerAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ManufacturerViewModel> GetManufacturerInHome()
        {
            var model = _dbContext.Manufacturers
                .Select(x => new ManufacturerViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    AvatarUrl = x.AvatarUrl,
                })
                .ToList();
            return model;
        }
    }
}
