using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public string OrderRef { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

    }
}
