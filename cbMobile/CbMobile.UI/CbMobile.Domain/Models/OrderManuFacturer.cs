using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class OrderManuFacturer
    {
        public int Id { get; set; }
        public int CategoryProductId { get; set; }
        public CategoryProduct CategoryProducts { get; set; }
        public int ManufacturerID { get; set; }
        public Manufacturer Manufacturers { get; set; }
    }
}
