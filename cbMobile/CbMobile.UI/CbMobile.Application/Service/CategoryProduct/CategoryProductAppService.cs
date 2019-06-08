using CbMobile.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service.CategoryProduct
{
    public class CategoryProductAppService : ICategoryProductAppService
    {
        private ApplicationDbContext _dbContext;
        public CategoryProductAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
