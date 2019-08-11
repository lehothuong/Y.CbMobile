using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface ICategoryPostAppService
    {
        IEnumerable<CategoryPostViewModel> GetCategoryNewMenu();
        IEnumerable<CategoryPostViewModel> GetListById(int id);
    }
}
