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
        Object GetAllCategory(int page = 1, int pageSize = 10);
        CategoryProduct GetDetailsCategoryProduct(int id);
        bool CreateCategoryProduct(CategoryProduct categoryProduct);
        bool UpdateCategoryProduct(CategoryProduct categoryProduct);
        IEnumerable<ManufacturerViewModel> GetManuByProductId(int categoryProductid);
        bool DeleteCategoryProduct(int id);
        Object GetListDropdownCategoryProduct();
    }
}
