using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface IProductAppService
    {
        IEnumerable<ProductViewModel> GetProduct();
        IEnumerable<CategoryProductViewModel> GetPhoneProductInHome();
        ProductViewModel GetDetails(int id);
        IEnumerable<ProductViewModel> GetGenericProduct(int id);
        IEnumerable<ProductViewModel> GetIndexProductById(int id);
        IEnumerable<ProductViewModel> GetIndexManufactureById(int id, int idCategory);
    }
}
