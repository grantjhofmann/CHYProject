using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class OrderDetail
    {
        public Int32 OrderDetailID { get; set; }

        public virtual Purchase Purchase { get; set; }

        public virtual Product Product { get; set; }

        public Decimal ExtendedPrice { get; set; }
    }
}