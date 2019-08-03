using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.ViewModels
{
    public class OrderManufacturerViewModel
    {
        public int Id { get; set; }
        public int CategoryProductId { get; set; }
        public CategoryProduct CategoryProducts { get; set; }
        public int ManufacturerID { get; set; }
        public Manufacturer Manufacturers { get; set; }
    }
}
