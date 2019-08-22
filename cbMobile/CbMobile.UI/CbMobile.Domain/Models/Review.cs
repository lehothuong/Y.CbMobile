using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Review : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public int ReviewStar { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
