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
    public class CategoryPostAppService : ICategoryPostAppService
    {
        private ApplicationDbContext _dbContext;
        public CategoryPostAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<CategoryPostViewModel> GetCategoryNewMenu()
        {
            var model = _dbContext.Categories
                .Where(x => x.ParentId == (int)CategoryPostType.News)
                .Select(x => new CategoryPostViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();
            return model;
        }
        public IEnumerable<CategoryPostViewModel> GetListById(int id)
        {
            var model = _dbContext
                 .Categories
                 .Include(x => x.Posts)
                 .GetPublished()
                 .Where(x => x.Id == id)
                 .Select(x => new CategoryPostViewModel
                 {
                     Name = x.Name,
                     Posts = x.Posts
                     .Select(y => new PostViewModel
                     {
                         Id = y.Id,
                         BannerUrl = y.BannerUrl,
                         Name = y.Name,
                         ShortDescription = y.ShortDescription,
                         FullDescription = y.FullDescription,
                     })
                 })
                 .ToList();
            return model;
        }
        public Object GetAllCategoryPost(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
               .Categories
               .GetPublished()
               .AsNoTracking()
               .OrderBy(x => x.DisplayOrder)
               .ThenByDescending(x => x.CreatedDate)
               .Where(x => x.ParentId == (int)CategoryPostType.News);
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
        public Object GetListDropdownCategoryPost()
        {
            return _dbContext
                  .Categories
                  .AsNoTracking()
                  .GetPublished()
                  .OrderBy(x => x.DisplayOrder)
                  .ThenByDescending(x => x.CreatedDate)
                  .Where(x => x.ParentId == (int)CategoryPostType.News)
                  .Select(x => new
                  {
                      Id = x.Id,
                      Name = x.Name
                  })
                  .ToList();
        }
        public Categories GetDetailsCategoryPost(int id)
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
        public bool CreateCategoryPost(Categories categories)
        {
            categories.ParentId = (int)CategoryPostType.News;
            _dbContext.Categories.Add(categories);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateCategoryPost(Categories categories)
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
                model.ParentId = (int)CategoryPostType.News;

                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
        public bool DeleteCategoryPost(int id)
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
