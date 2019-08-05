using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service.CategoryProduct
{
    public interface ICategoryProductAppService
    {
        IEnumerable<CategoryProductViewModel> GetMenuCategory();
        CategoryProductViewModel GetCategoryProductById(int id);
    }
}
