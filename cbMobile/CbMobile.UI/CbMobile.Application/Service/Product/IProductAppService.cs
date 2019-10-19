using CbMobile.Domain.Models;
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
        Object GetAllProduct(int page = 1, int pageSize = 10);
        Product GetDetailsProduct(int id);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        List<int> GetArrListMemory(string strListMemoryId);
    }
}
