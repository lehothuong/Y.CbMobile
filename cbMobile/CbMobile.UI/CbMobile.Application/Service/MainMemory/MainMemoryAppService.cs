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
    public class MainMemoryAppService : IMainMemoryAppService
    {
        private ApplicationDbContext _dbContext;
        public MainMemoryAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Object GetAllMainMemory(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
                .MainMemorys
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
        public Object GetListMainMemory()
        {
            return _dbContext
                .MainMemorys
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
        public MainMemory GetDetailMainMemory(int id)
        {
            var model = _dbContext
                  .MainMemorys
                  .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool CreateMainMemory(MainMemory mainMemory)
        {
            _dbContext.MainMemorys.Add(mainMemory);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateMainMemory(MainMemory mainMemory)
        {
            var model = _dbContext
                 .MainMemorys
                 .FirstOrDefault(x => x.Id == mainMemory.Id);
            if(model != null)
            {
                model.Name = mainMemory.Name;
                model.DisplayOrder = mainMemory.DisplayOrder;
                model.UpdatedDate = mainMemory.UpdatedDate;
                model.Value = mainMemory.Value;
                model.Published = mainMemory.Published;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteMainMemory(int id)
        {
            var model = _dbContext
                 .MainMemorys
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
