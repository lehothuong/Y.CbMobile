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
    public class LocationAppService : ILocationAppService
    {
        private ApplicationDbContext _dbContext;
        public LocationAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
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
    }
}
