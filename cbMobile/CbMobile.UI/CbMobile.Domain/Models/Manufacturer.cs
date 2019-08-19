using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Manufacturer : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string AvatarUrl { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<OrderManuFacturer> OrderManuFacturers { get; set; }
    }
}
