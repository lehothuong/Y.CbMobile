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
                 .Where(x => x.Id == id)
                 .Select(x => new CategoryPostViewModel
                 {
                     Name = x.Name,
                     Posts = x.Posts.Select(y => new PostViewModel
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
    }
}
