using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Post : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string AvatarUrl { get; set; }
        public string BannerUrl { get; set; }
        public string CategoryPostType { get; set; }
        [ForeignKey("Categories")]
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
    }
}
