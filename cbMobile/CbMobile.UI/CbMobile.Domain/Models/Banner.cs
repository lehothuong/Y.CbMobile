using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Banner : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string BannerUrl { get; set; }
        public string BannerCategory { get; set; }
    }
}
