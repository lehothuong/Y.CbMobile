using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string AvatarUrl { get; set; }
        public string FullDescription { get; set; }
        public decimal? Value { get; set; }
        public decimal? ValuePromotion { get; set; }
        public bool Hot { get; set; }
        public bool Status { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string MainMemory { get; set; }
        [NotMapped]
        public List<int> ListMemory
        {
            get
            {
                return !string.IsNullOrEmpty(this.MainMemory) ? this.MainMemory.Split(',').Select(p => int.Parse(p)).ToList() : new List<int>();
            }
            set
            {
                this.MainMemory = string.Join(",", value);
            }
        }
        [ForeignKey("CategoryProduct")]
        public int CategoryProductId { get; set; }
        public CategoryProduct CategoryProduct { get; set; }
        public IEnumerable<Review> Reivews { get; set; }
        public IEnumerable<DetailSpecification> DetailSpecifications { get; set; }
        public IEnumerable<DetailAccessories> DetailAccessories { get; set; }
        public IEnumerable<DetailBill> DetailBills { get; set; }
    }

}
