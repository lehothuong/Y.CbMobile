using CbMobile.Database;
using CbMobile.Domain;
using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        public Object GetAllBanner(int page = 1,int pageSize = 10)
        {
            var model = _dbContext
                 .Banners
                 .AsNoTracking()
                 .Where(x => !x.Deleted)
                 .OrderBy(x => x.DisplayOrder)
                 .ThenByDescending(x => x.CreatedDate);
            var totalCount = model.Count();
            var results = model
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
            
            return new {
                totalCount = totalCount,
                data = results
            };
        }
        public Banner GetDetailsBanner(int id)
        {
            var model = _dbContext
                .Banners
                .FirstOrDefault(x => x.Id == id);
            if(model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool CreateBanner(Banner banner)
        {
            _dbContext.Banners.Add(banner);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateBanner(Banner banner)
        {
            var model = _dbContext
               .Banners
               .GetPublished()
               .FirstOrDefault(x => x.Id == banner.Id);
            if(model != null)
            {
                model.Name = banner.Name;
                model.Published = banner.Published;
                model.BannerCategory = banner.BannerCategory;
                model.BannerUrl = banner.BannerUrl;
                model.Deleted = banner.Deleted;
                model.DisplayOrder = banner.DisplayOrder;
                model.Url = banner.Url;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteBanner(int id)
        {
            var model = _dbContext
              .Banners
              .FirstOrDefault(x => x.Id == id);
            if(model != null)
            {
                model.Deleted = true;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
