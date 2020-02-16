using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public abstract partial class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
        }
        public virtual bool Deleted { get; set; }

        public virtual bool Published { get; set; } = true;

        public virtual int DisplayOrder { get; set; } = 0;

        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual DateTime CreatedOnUtc { get; set; }
        public virtual DateTime UpdatedOnUtc { get; set; }
    }
}
