using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
