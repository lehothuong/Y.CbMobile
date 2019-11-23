using CbMobile.Database;
using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CbMobile.Application.Service
{
    public class CommonAppService : ICommonAppService
    {
        private ApplicationDbContext _dbContext;
        public CommonAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
    public class DropDownYesNo
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
