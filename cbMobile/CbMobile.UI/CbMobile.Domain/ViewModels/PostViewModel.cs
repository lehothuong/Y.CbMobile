using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.ViewModels
{
    public class PostViewModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string AvatarUrl { get; set; }
        public string BannerUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
    }
}
