using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface ICategoryProductAppService
    {
        IEnumerable<CategoryProductViewModel> GetMenuCategory();
        CategoryProductViewModel GetCategoryProductById(int id);
        IEnumerable<CategoryProduct> GetAllCategory();
        CategoryProduct GetDetailsCategoryProduct(int id);
        CategoryProduct CreateCategoryProduct(CategoryProduct categoryProduct);
        bool UpdateCategoryProduct(CategoryProduct categoryProduct);
        bool DeleteCategoryProduct(int id);
    }
}
