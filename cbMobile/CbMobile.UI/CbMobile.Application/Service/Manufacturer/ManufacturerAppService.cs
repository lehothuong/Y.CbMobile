using CbMobile.Database;
using CbMobile.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobile.Application.Service
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
        public List<ManufacturerViewModel> GetManuFacturerById(int id)
        {
            var manuFacturerIds = _dbContext
                 .OrderManuFacturers
                 .Where(x => x.CategoryProductId == id)
                 .Select(x => new
                 {
                    ManufacturerID = x.ManufacturerID
                 })
                 .ToList();

            var modelManuFacturers = _dbContext
                 .Manufacturers
                 .Where(x => manuFacturerIds.Select(p => p.ManufacturerID).Contains(x.Id))
                 .Select(x => new ManufacturerViewModel {
                     Id = x.Id,
                     Name = x.Name,
                 })
                 .ToList();
            return modelManuFacturers;
        }
        public ManufacturerViewModel GetManufacturerById(int id)
        {
            var model = _dbContext
                 .Manufacturers
                 .FirstOrDefault(x => x.Id == id);
            if(model != null)
            {
                return new ManufacturerViewModel()
                {
                    Name = model.Name
                };
            }
            throw new KeyNotFoundException();
        }
    }
}
