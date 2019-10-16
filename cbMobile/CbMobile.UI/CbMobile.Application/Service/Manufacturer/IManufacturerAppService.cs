using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface IManufacturerAppService
    {
        IEnumerable<ManufacturerViewModel> GetManufacturerInHome();
        List<ManufacturerViewModel> GetManuFacturerById(int id);
        ManufacturerViewModel GetManufacturerById(int id);
        Object GetAllManufacturer(int page = 1, int pageSize = 10);
        Manufacturer GetDetailsManufacturer(int id);
        bool CreateManufacturer(Manufacturer manufacturer);
        bool UpdateManufacturer(Manufacturer manufacturer);
        bool DeleteCategoryProduct(int id);
        Object GetListDropdownManufacturer();
    }
}
