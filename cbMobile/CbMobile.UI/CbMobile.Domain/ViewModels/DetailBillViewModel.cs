using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.ViewModels
{
    public class DetailBillViewModel
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int MainColorId { get; set; }
        public int MainMemoryId { get; set; }
        public string ColorName { get; set; }
        public string MemoryName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
        public Product Product { get; set; }
    }
}
