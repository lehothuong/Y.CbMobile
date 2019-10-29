using System;
using System.Collections.Generic;
using System.Text;
using CbMobile.Domain.Models;

namespace CbMobile.Application.Service
{
    public interface IContactAppService
    {
        Contact PostContact(Contact contact);
        Object AdminGetAllContact(int page = 1, int pageSize = 10);
        bool DeleteContact(int id);
    }
}
