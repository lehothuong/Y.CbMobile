using CbMobile.Database;
using CbMobile.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobile.Application.Service
{
    public class ContactAppService : IContactAppService
    {
        private ApplicationDbContext _dbContext;
        public ContactAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Contact PostContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return contact;
        }

        public Object AdminGetAllContact(int page = 1, int pageSize = 10)
        {
            var model = _dbContext
               .Contacts
               .Where(x => !x.Deleted)
               .AsNoTracking()
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
        public bool DeleteContact(int id)
        {
            var model = _dbContext
                 .Contacts
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
