using CbMobile.Database;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobile.Application.Service
{
    public class BannerAppService : IBannerAppService
    {
        private ApplicationDbContext _dbContext;
        public BannerAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<BannerViewModel> GetBannerHome()
        {
            var model = _dbContext
                 .Banners
                 .Where(x => x.BannerCategory == BannerCategoryType.HomeTopBanner)
                 .Select(x => new BannerViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Url = x.Url,
                     BannerUrl = x.BannerUrl
                 })
                 .ToList();
            return model;
        }
    }
}
