using CbMobile.Application;
using CbMobile.Database;
using CbMobile.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobileApplication.Service.CategoryPost
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
                    Name = x.Name,
                })
                .ToList();
            return model;
        }
    }
}
