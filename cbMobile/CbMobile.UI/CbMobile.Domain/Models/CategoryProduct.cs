using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class CategoryProduct : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainProductCategory { get; set; }
        [NotMapped]
        public List<int> ListManufacturer
        {
            get
            {
                return !string.IsNullOrEmpty(this.MainProductCategory) ? this.MainProductCategory.Split(',').Select(p => int.Parse(p)).ToList() : new List<int>();
            }
            set
            {
                this.MainProductCategory = string.Join(",", value);
            }
        }
        public ICollection<Product> Products { get; set; }
        public ICollection<OrderManuFacturer> OrderManuFacturers { get; set; }
    }
}
