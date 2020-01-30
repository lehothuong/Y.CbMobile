using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class DetailSpecification : BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Products { get; set; }
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public Specification Specification { get; set; }
    }   

}
