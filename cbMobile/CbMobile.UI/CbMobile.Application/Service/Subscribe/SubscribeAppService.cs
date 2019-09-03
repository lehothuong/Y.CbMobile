using CbMobile.Database;
using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public class SubscribeAppService : ISubscribeAppService
    {
        private ApplicationDbContext _dbContext;
        public SubscribeAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Subscribe PostSubscribe(Subscribe subscribe)
        {
            _dbContext.Subscribes.Add(subscribe);
            _dbContext.SaveChanges();
            return subscribe;
        }
    }
}
