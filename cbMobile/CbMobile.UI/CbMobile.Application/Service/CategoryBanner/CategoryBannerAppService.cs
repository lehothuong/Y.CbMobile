using CbMobile.Application;
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
    public class CategoryBannerAppService : ICategoryBannerAppService
    {
        private ApplicationDbContext _dbContext;
        public CategoryBannerAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Object GetAllCategoryBanner(int page = 1,int pageSize = 10)
        {
            var model = _dbContext
               .Categories
               .Where(x => !x.Deleted)
               .AsNoTracking()
               .OrderBy(x => x.DisplayOrder)
               .ThenByDescending(x => x.CreatedDate)
               .Where(x => x.ParentId == (int)CategoryPostType.Banners);
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
        public Object GetListDropdownCategoryBanner()
        {
            return _dbContext
                  .Categories
                  .AsNoTracking()
                  .GetPublished()
                  .OrderBy(x => x.DisplayOrder)
                  .ThenByDescending(x => x.CreatedDate)
                  .Where(x => x.ParentId == (int)CategoryPostType.Banners)
                  .Select(x => new
                  {
                      Id = x.Id,
                      Name = x.Name
                  })
                  .ToList();
        }
        public Categories GetDetailsCategoryBanner(int id)
        {
            var model = _dbContext
                  .Categories
                  .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool CreateCategoryBanner(Categories categories)
        {
            categories.ParentId = (int)CategoryPostType.Banners;
            _dbContext.Categories.Add(categories);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateCategoryBanner(Categories categories)
        {
            var model = _dbContext
                 .Categories
                 .FirstOrDefault(x => x.Id == categories.Id);
            if (model != null)
            {
                model.Name = categories.Name;
                model.DisplayOrder = categories.DisplayOrder;
                model.UpdatedDate = categories.UpdatedDate;
                model.Published = categories.Published;
                model.ParentId = (int)CategoryPostType.Banners;

                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
        public bool DeleteCategoryBanner(int id)
        {
            var model = _dbContext
                 .Categories
                 .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                model.Deleted = true;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
