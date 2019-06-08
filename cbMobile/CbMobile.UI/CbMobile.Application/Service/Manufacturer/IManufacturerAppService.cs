using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service.Manufacturer
{
    public interface IManufacturerAppService
    {
        IEnumerable<ManufacturerViewModel> GetManufacturerInHome();
    }
}
