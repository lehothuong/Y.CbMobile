using CbMobile.Application;
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
    public class LocationAppService : ILocationAppService
    {
        private ApplicationDbContext _dbContext;
        public LocationAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region UI
        public IEnumerable<LocationViewModel> GetAllLocation()
        {
            var model = _dbContext
                 .Locations
                 .Select(x => new LocationViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     ShortDescription = x.ShortDescription,
                     Address = x.Address,
                     PhoneNumber = x.PhoneNumber,
                     Email = x.Email
                 })
                 .ToList();
            return model;
        }
        #endregion

        #region Admin
        public Object AdminGetAllLocation(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
              .Locations
              .AsNoTracking()
              .Where(x => !x.Deleted)
              .OrderBy(x => x.DisplayOrder)
              .ThenByDescending(x => x.CreatedDate)
              .Select(x => new LocationViewModel
              {
                  Id = x.Id,
                  Name = x.Name,
                  CreatedDate = x.CreatedDate,
                  DisplayOrder = x.DisplayOrder,
                  ShortDescription = x.ShortDescription,
                  Address = x.Address,
                  PhoneNumber = x.PhoneNumber,
                  Email = x.Email
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
        public Location GetDetailsLocation(int id)
        {
            var model = _dbContext
                  .Locations
                  .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool CreateLocation(Location location)
        {
            _dbContext.Locations.Add(location);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateLocation(Location location)
        {
            var model = _dbContext
                 .Locations
                 .FirstOrDefault(x => x.Id == location.Id);
            if (model != null)
            {
                model.Name = location.Name;
                model.DisplayOrder = location.DisplayOrder;
                model.UpdatedDate = location.UpdatedDate;
                model.ShortDescription = location.ShortDescription;
                model.Published = location.Published;
                model.Address = location.Address;
                model.PhoneNumber = location.PhoneNumber;
                model.Email = location.Email;

                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteLocation(int id)
        {
            var model = _dbContext
                 .Locations
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
    }
}
