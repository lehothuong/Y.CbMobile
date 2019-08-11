using CbMobile.Database;
using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
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
    }
}
