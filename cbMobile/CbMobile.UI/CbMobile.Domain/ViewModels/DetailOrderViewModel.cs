using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.ViewModels
{
    public class DetailOrderViewModel
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int MainColorId { get; set; }
        public int MainMemoryId { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string mainColorName { get; set; }
        public string mainMemoryName { get; set; }
    }
}
