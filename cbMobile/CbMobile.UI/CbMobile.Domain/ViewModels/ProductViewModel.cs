using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string AvatarUrl { get; set; }
        public string FullDescription { get; set; }
        public decimal? Value { get; set; }
        public decimal? ValuePromotion { get; set; }
        public bool Hot { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryProductId { get; set; }
        public bool Status { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual bool Published { get; set; }
        public virtual int DisplayOrder { get; set; } = 0;
        public virtual DateTime CreatedDate { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public CategoryProduct CategoryProduct { get; set; }
        public IList<int> ListMemory { get; set; }
    }
}
