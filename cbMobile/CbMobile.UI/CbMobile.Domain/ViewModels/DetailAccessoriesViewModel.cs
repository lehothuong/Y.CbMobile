using CbMobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.ViewModels
{
    public class DetailAccessoriesViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string MainColorName { get; set; }
        public string MainMemoryName { get; set; }
        public virtual int DisplayOrder { get; set; } = 0;
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual bool Published { get; set; }
    }
}
