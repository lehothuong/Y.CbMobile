﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobileDomain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string AvatarUrl { get; set; }
        public string FullDescription { get; set; }
        public decimal Value { get; set; }
        public bool Hot { get; set; }
        public bool Status { get; set; }
        public string Screen { get; set; }
        public string CameraHead { get; set; }
        public string CameraAfter { get; set; }
        public int Ram { get; set; }
        public int MainMemory { get; set; }
        public int Memoryexception { get; set; }
        public string GPU { get; set; }
        public string BatteryCapacity { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
