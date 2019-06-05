using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobileApplication.Service.Product
{
    public interface IProductAppService
    {
        IEnumerable<ProductViewModel> GetProduct();
    }
}
