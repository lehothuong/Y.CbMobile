using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain
{
    public enum CategoryProductType
    {
       SmartPhone = 1
    }

    public enum CategoryPostType
    {
        Topic = 1,
        News = 2
    }
    public enum PulishType
    {
        No = 0,
        Yes = 1
    }
    public enum CategoryPostTypeNews
    {
        NewsTechnology = 3,
    }

    public static class ListColor
    {
        public static string Black = "Đen";
        public static string White = "Trắng";
        public static string Green = "Xanh";
    }
    public static class BannerCategoryType
    {
         public static string HomeTopBanner = "Home Top Banner";
    }
}
