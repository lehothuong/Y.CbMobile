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
    public class PostAppService : IPostAppService
    {
        private ApplicationDbContext _dbContext;
        public PostAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<PostViewModel> GetAboutUs()
        {
            var model = _dbContext.Posts
                .Include(x => x.Categories)
                .Where(x => x.CategoriesId == (int)CategoryPostType.Topic)
                .Select(x => new PostViewModel
                {
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    CreateDate = x.CreatedDate,
                    FullDescription = x.FullDescription,
                    AvatarUrl = x.AvatarUrl
                })
                .ToList();
            return model;
        }

        public IEnumerable<PostViewModel> GetAllNews()
        {
            var model = _dbContext.Posts
                .Include(x => x.Categories)
                .Where(x => x.CategoriesId == (int)CategoryPostType.News)
                .Select(x => new PostViewModel
                {
                    BannerUrl = x.BannerUrl,
                    Name = x.Name,
                    CreateDate = x.CreatedDate,
                    ShortDescription = x.ShortDescription,
                    FullDescription = x.FullDescription,
                })
                .ToList();
            return model;
        }

        public IEnumerable<PostViewModel> GetNewTechnology()
        {
            var model = _dbContext.Posts
                .Include(x => x.Categories)
                .Where(x => x.CategoriesId == (int)CategoryPostTypeNews.NewsTechnology)
                .Take(3)
                .Select(x => new PostViewModel
                {
                    Id = x.Id,
                    BannerUrl = x.BannerUrl,
                    Name = x.Name,
                    CreateDate = x.CreatedDate,
                    ShortDescription = x.ShortDescription,
                    FullDescription = x.FullDescription,
                    CategoriesId = x.CategoriesId
                })
                .ToList();
            return model;
        }
        public PostViewModel GetDetails(int id)
        {
            var model = _dbContext
                 .Posts
                 .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return new PostViewModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    CreateDate = model.CreatedDate,
                    ShortDescription = model.ShortDescription,
                    FullDescription = model.FullDescription,
                };
            }
            throw new KeyNotFoundException();
        }
    }
}
