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
    public class SearchAppService : ISearchAppService
    {
        private ApplicationDbContext _dbContext;
        public SearchAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<ProductViewModel> Filter(string keyword)
        {
            var model = _dbContext
                         .Products
                         .AsNoTracking()
                         .GetPublished()
                         .OrderBy(x => x.DisplayOrder)
                         .ThenByDescending(x => x.CreatedDate)
                         .Where(x => x.Name.Contains(keyword.Trim()))
                         .Select(x => new ProductViewModel {
                             Id = x.Id,
                             Name = x.Name,
                             AvatarUrl = x.AvatarUrl,
                             ValuePromotion = x.ValuePromotion
                         })
                         .ToList();
                return model;
        }
    }
}
