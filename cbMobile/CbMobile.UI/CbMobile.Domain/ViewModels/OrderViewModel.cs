using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Payment { get; set; }
        public string Content { get; set; }
        public string TotalBill { get; set; }
        public bool IsPay { get; set; }
        public List<DetailOrderViewModel> Cart { get; set; }
        public List<DetailBill> DetailBills { get; set; }
    }
}
