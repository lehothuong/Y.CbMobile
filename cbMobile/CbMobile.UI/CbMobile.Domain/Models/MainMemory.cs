﻿using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class MainMemory : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public IEnumerable<DetailAccessories> DetailAccessories { get; set; }
    }   

}
