using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class DetailMemory : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public int MainMemoryId { get; set; }
        public MainMemory MainMemory { get; set; }
    }   

}
