using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class CategoryProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<OrderManuFacturer> OrderManuFacturers { get; set; }
    }
}
