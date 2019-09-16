using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Specification : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DetailSpecification> DetailSpecifications { get; set; }
    }   

}
