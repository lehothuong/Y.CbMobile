using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.ViewModels
{
    public class CategoryProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public List<ManufacturerViewModel> ListManufacturer { get; set; }
        public string MainProductCategory { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<OrderManufacturerViewModel> OrderManufacturers { get; set; }
    }
}
