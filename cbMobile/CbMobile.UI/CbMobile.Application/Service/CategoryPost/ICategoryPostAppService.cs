using CbMobile.Domain.Models;
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
        Object GetAllCategoryPost(int page = 1, int pageSize = 10);
        Object GetListDropdownCategoryPost();
        Categories GetDetailsCategoryPost(int id);
        bool CreateCategoryPost(Categories categories);
        bool UpdateCategoryPost(Categories categories);
        bool DeleteCategoryPost(int id);
    }
}
