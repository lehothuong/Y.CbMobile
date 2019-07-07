using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobileApplication.Service.CategoryPost
{
    public interface ICategoryPostAppService
    {
        IEnumerable<CategoryPostViewModel> GetCategoryNewMenu();
    }
}
