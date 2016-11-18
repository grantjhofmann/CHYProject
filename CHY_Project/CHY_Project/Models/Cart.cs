using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class Cart
    {
        public Int32 CartID { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual AppUser Customer { get; set; }
    }
}