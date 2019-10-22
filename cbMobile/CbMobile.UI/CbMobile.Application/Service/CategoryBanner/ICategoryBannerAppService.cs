using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface ICategoryBannerAppService
    {
        Object GetAllCategoryBanner(int page = 1, int pageSize = 10);
        Object GetListDropdownCategoryBanner();
        Categories GetDetailsCategoryBanner(int id);
        bool CreateCategoryBanner(Categories categories);
        bool UpdateCategoryBanner(Categories categories);
        bool DeleteCategoryBanner(int id);
    }
}
