using CbMobile.Application;
using CbMobile.Database;
using CbMobile.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobileApplication.Service.Post
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
                    CreateDate = x.CreateDate,
                    ShortDescription = x.ShortDescription,
                    FullDescription = x.FullDescription,
                })
                .ToList();
            return model;
        }
    }
}
