﻿using System;
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
    public static class PostType
    {
        public static string News = "NewsCategory";
        public static string Topic = "TopicCategory";
    }
}
