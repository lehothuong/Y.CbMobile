using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public string AvatarUrl { get; set; }
        public string BannerUrl { get; set; }
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
    }
}
