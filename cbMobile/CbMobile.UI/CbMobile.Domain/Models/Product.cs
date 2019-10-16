using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
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
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string MainMemory { get; set; }
        public int CategoryProductId { get; set; }
        public CategoryProduct CategoryProduct { get; set; }
        public IEnumerable<Review> Reivews { get; set; }
        public IEnumerable<DetailSpecification> DetailSpecifications { get; set; }
    }   

}
