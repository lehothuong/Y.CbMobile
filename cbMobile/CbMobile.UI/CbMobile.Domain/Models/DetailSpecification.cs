using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class DetailSpecification : BaseEntity
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public Product Products { get; set; }
        public int IdSpecification { get; set; }
        public Specification Specification { get; set; }
    }   

}
