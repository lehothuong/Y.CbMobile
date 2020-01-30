using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface ISpecificationAppService
    {
        Object AdminGetAllSpecification(int page = 1, int pageSize = 10);
        Specification GetDetailSpecification(int id);
        bool CreateSpecification(Specification specification);
        bool UpdateSpecification(Specification specification);
        bool DeleteSpecification(int id);
        Object GetListDropdownSpecification();
    }
}
