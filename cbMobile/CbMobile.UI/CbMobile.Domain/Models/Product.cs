using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobileDomain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string AvatarUrl { get; set; }
        public string FullDescription { get; set; }
        public decimal Value { get; set; }
    }
}
