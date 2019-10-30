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
                .GetPublished()
                .AsNoTracking()
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
                .GetPublished()
                .AsNoTracking()
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
            var model = _dbContext
                .Posts
                .GetPublished()
                .AsNoTracking()
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
        public IEnumerable<PostViewModel> GetListNewByIdCategory(int id)
        {
            var model = _dbContext
                .Posts
                .GetPublished()
                .AsNoTracking()
                .Where(x => x.CategoriesId == id)
                .Select(x => new PostViewModel
                {
                    Id = x.Id,
                    BannerUrl = x.BannerUrl,
                    AvatarUrl = x.AvatarUrl,
                    Name = x.Name,
                    CreateDate = x.CreatedDate,
                    ShortDescription = x.ShortDescription,
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
        public Object GetAllPost(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
                 .Posts
                 .AsNoTracking()
                 .Where(x => !x.Deleted)
                 .Where(x => x.CategoryPostType == PostType.News)
                 .OrderBy(x => x.DisplayOrder)
                 .ThenByDescending(x => x.CreatedDate);
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
        public Post GetDetailsPost(int id)
        {
            var model = _dbContext
                .Posts
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool CreatePost(Post post)
        {
            post.CategoryPostType = PostType.News;
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdatePost(Post post)
        {
            var model = _dbContext
               .Posts
               .GetPublished()
               .FirstOrDefault(x => x.Id == post.Id);
            if (model != null)
            {
                model.Name = post.Name;
                model.Published = post.Published;
                model.BannerUrl = post.BannerUrl;
                model.AvatarUrl = post.AvatarUrl;
                model.Deleted = post.Deleted;
                model.UpdatedDate = post.UpdatedDate;
                model.FullDescription = model.FullDescription;
                model.ShortDescription = model.ShortDescription;
                model.DisplayOrder = post.DisplayOrder;
                model.CategoriesId = post.CategoriesId;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeletePost(int id)
        {
            var model = _dbContext
              .Posts
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
