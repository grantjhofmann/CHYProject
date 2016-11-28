using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CHY_Project.Models
{
    public class OrderDetail
    {
        public Int32 OrderDetailID { get; set; }

        
        public virtual Purchase Purchase { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [Required]
        public Decimal ExtendedPrice { get; set; }
    }
}