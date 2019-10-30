using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain
{
    public enum CategoryProductType
    {
       SmartPhone = 2
    }

    public enum CategoryPostType
    {
        Topic = 3,
        News = 5,
        Banners = 6,
    }
    public enum PulishType
    {
        No = 0,
        Yes = 1
    }
    public enum CategoryPostTypeNews
    {
        NewsTechnology = 8,
    }

    public static class ListColor
    {
        public static string Black = "Đen";
        public static string White = "Trắng";
        public static string Green = "Xanh";
    }
    public enum BannerCategoryType
    {
        HomeTopBanner = 7,
    }
    public static class PostType
    {
        public static string News = "NewsCategory";
        public static string Topic = "TopicCategory";
    }
}
