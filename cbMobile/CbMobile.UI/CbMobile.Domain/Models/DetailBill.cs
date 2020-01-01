using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class DetailBill : BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Bill")]
        public int BillId { get; set; }
        public string ColorName { get; set; }
        public string MemoryName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public Product Product { get; set; }
        public Bill Bill { get; set; }
    }
}
