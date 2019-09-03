using CbMobile.Database;
using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobile.Application.Service
{
    public class ReviewAppService : IReviewAppService
    {
        private ApplicationDbContext _dbContext;
        public ReviewAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Review PostReview(Review review)
        {
            _dbContext.Review.Add(review);
            _dbContext.SaveChanges();
            return review;
        }
        public IEnumerable<ReviewViewModel> GetAllReviewByProductId(int id)
        {
            var model = _dbContext
                .Review
                .AsNoTracking()
                .Where(x => x.ProductId == id)
                .Select(x => new ReviewViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ReviewStar = x.ReviewStar,
                    Email = x.Email,
                    Title = x.Title,
                    CreateDate = x.CreatedDate.ToString("dd/MM/yyyy"),
                    Content = x.Content
                })
                .ToList();
            return model;
        }
    }
}
