using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface IReviewAppService
    {
        Review PostReview(Review review);
        IEnumerable<ReviewViewModel> GetAllReviewByProductId(int id);
        Object AdminGetAllReview(int page = 1, int pageSize = 10);
        bool DeleteReview(int id);
    }
}
