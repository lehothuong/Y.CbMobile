using CbMobile.Database;
using CbMobile.Domain.Models;
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
        public Object GetAllManufacturer(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
                  .Manufacturers
                  .AsNoTracking()
                  .GetPublished()
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
        public Object GetListDropdownManufacturer()
        {
            return _dbContext
                  .Manufacturers
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
        public Manufacturer GetDetailsManufacturer(int id)
        {
            var model = _dbContext
                  .Manufacturers
                  .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool CreateManufacturer(Manufacturer manufacturer)
        {
            _dbContext.Manufacturers.Add(manufacturer);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateManufacturer(Manufacturer manufacturer)
        {
            var model = _dbContext
                 .Manufacturers
                 .FirstOrDefault(x => x.Id == manufacturer.Id);
            if (model != null)
            {
                model.Name = manufacturer.Name;
                model.DisplayOrder = manufacturer.DisplayOrder;
                model.UpdatedDate = manufacturer.UpdatedDate;
                model.Published = manufacturer.Published;
                model.ShortDescription = manufacturer.ShortDescription;
                model.AvatarUrl = manufacturer.AvatarUrl;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteCategoryProduct(int id)
        {
            var model = _dbContext
                 .Manufacturers
                 .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                model.Deleted = true;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
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
                 .Select(x => new ManufacturerViewModel
                 {
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
            if (model != null)
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
