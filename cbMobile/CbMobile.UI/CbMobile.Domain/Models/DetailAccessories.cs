using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class DetailAccessories : BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("MainMemory")]
        public int MainMemoryId { get; set; }
        public MainMemory MainMemory { get; set; }
        [ForeignKey("MainColor")]
        public int MainColorId { get; set; }
        public MainColor MainColor { get; set; }
        public decimal? Value { get; set; }
        public decimal? ValuePromotion { get; set; }
    }   

}
