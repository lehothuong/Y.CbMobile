using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Categories : BaseEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Banner> Banners { get; set; }
    }
}
