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
    public class TopicAppService : ITopicAppService
    {
        private ApplicationDbContext _dbContext;
        public TopicAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Object AdminGetAllTopic(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
               .Posts
               .AsNoTracking()
               .GetPublished()
               .Where(x => x.CategoriesId == (int)CategoryPostType.Topic && x.CategoryPostType == PostType.Topic)
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
        public Post GetDetailsTopic(int id)
        {
            var model = _dbContext
                  .Posts
                  .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool CreateTopic(Post post)
        {
            post.CategoryPostType = PostType.Topic;
            post.CategoriesId = (int)CategoryPostType.Topic;
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateTopic(Post post)
        {
            var model = _dbContext
                 .Posts
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

                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
        public bool DeleteTopic(int id)
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
