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
    public class MainColorAppService : IMainColorAppService
    {
        private ApplicationDbContext _dbContext;
        public MainColorAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Object GetAllMainColor(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
                .MainColors
                .AsNoTracking()
                .Where(x => !x.Deleted)
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.CreatedDate);
            var totalCount = model.Count();
            var results = model
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize).ToList();
            return new
            {
                totalCount = totalCount,
                data = results
            };
        }
        public Object GetListMainColor()
        {
            return _dbContext
                .MainColors
                .AsNoTracking()
                .GetPublished()
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.CreatedDate)
                .Select(x => new
                {
                    Text = x.Name,
                    Value = x.Id,
                })
                .ToList();
        }
        public MainColor GetDetailMainColor(int id)
        {
            var model = _dbContext
                  .MainColors
                  .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool CreateMainColor(MainColor mainColor)
        {
            _dbContext.MainColors.Add(mainColor);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateMainColor(MainColor mainColor)
        {
            var model = _dbContext
                 .MainColors
                 .FirstOrDefault(x => x.Id == mainColor.Id);
            if(model != null)
            {
                model.Name = mainColor.Name;
                model.DisplayOrder = mainColor.DisplayOrder;
                model.UpdatedDate = mainColor.UpdatedDate;
                model.Published = mainColor.Published;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteMainColor(int id)
        {
            var model = _dbContext
                 .MainColors
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
