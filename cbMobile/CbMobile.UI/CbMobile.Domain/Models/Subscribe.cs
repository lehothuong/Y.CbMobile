using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Domain.Models
{
    public class Subscribe : BaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
