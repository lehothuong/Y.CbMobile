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
    public class SpecificationAppService : ISpecificationAppService
    {
        private ApplicationDbContext _dbContext;
        public SpecificationAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Object AdminGetAllSpecification(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
               .Specifications
               .AsNoTracking()
               .Where(x => !x.Deleted)
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
        public Specification GetDetailSpecification(int id)
        {
            var model = _dbContext
                  .Specifications
                  .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool CreateSpecification(Specification specification)
        {
            _dbContext.Specifications.Add(specification);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateSpecification(Specification specification)
        {
            var model = _dbContext
                 .Specifications
                 .FirstOrDefault(x => x.Id == specification.Id);
            if (model != null)
            {
                model.Published = specification.Published;
                model.Name = specification.Name;
                model.DisplayOrder = specification.DisplayOrder;
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
        public bool DeleteSpecification(int id)
        {
            var model = _dbContext
                 .Specifications
                 .FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                model.Deleted = true;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public Object GetListDropdownSpecification()
        {
            return _dbContext
                  .Specifications
                  .AsNoTracking()
                  .GetPublished()
                  .OrderBy(x => x.DisplayOrder)
                  .ThenByDescending(x => x.CreatedDate)
                  .Select(x => new
                  {
                      Id = x.Id,
                      Name = x.Name
                  })
                  .ToList();
        }
        public bool CreateDetailSpecification(DetailSpecification detailSpecification)
        {
            _dbContext.DetailSpecifications.Add(detailSpecification);
            _dbContext.SaveChanges();
            return true;
        }
        public IEnumerable<Object> GetAllSpecificationById(int id)
        {
            var model = _dbContext
                           .DetailSpecifications
                           .Include(x => x.Specification)
                           .AsNoTracking()
                           .Where(x => !x.Deleted && x.ProductId == id)
                           .Where(x => x.Specification.Published && !x.Specification.Deleted)
                           .Select(x => new
                           {
                               Id = x.Id,
                               SpecificationName = x.Specification.Name,
                               Content = x.Content,
                               SpecificationId = x.SpecificationId,
                               DisplayOrder = x.DisplayOrder
                           })
                           .ToList();
            return model;
        }
        public DetailSpecification GetSpecificationById(int id,int productId, int specificationId)
        {
            var model = _dbContext
                            .DetailSpecifications
                            .FirstOrDefault(x => x.ProductId == productId && x.Id == id && x.SpecificationId == specificationId);
            if (model != null)
            {
                return model;
            }
            throw new KeyNotFoundException();
        }
        public bool UpdateDetailSpecification(DetailSpecification detailSpecification)
        {
            var model = _dbContext
                 .DetailSpecifications
                 .FirstOrDefault(x => x.ProductId == detailSpecification.ProductId && x.Id == detailSpecification.Id && x.SpecificationId == detailSpecification.SpecificationId);
            if (model != null)
            {
                model.Content = detailSpecification.Content;
                model.DisplayOrder = detailSpecification.DisplayOrder;
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
        public bool DeleteDetailSpecification(int id,int productId, int specificationId)
        {
            var model = _dbContext
                 .DetailSpecifications
                 .FirstOrDefault(x => x.ProductId == productId && x.Id == id && x.SpecificationId == specificationId);
            if (model != null)
            {
                model.Deleted = true;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<ObjectKeyValue> GetUISpecificationById(int id)
        {
            var model = _dbContext
                           .DetailSpecifications
                           .Include(x => x.Specification)
                           .AsNoTracking()
                           .GetPublished()
                           .Where(x => x.Specification.Published && !x.Specification.Deleted)
                           .Select(x => new ObjectKeyValue
                           {
                               Name = x.Specification.Name,
                               Text = x.Content,
                           })
                           .ToList();
            return model;
        }
    }
}
