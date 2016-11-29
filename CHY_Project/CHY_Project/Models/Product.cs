using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHY_Project.Models
{
    public abstract class Product : Content
    {
        [Key]
        public String ProductID { get; set; }

        public Decimal RegularPrice { get; set; }

        public Decimal DiscountPrice { get; set; }

        //NOTE: Can artists be featured? If so, this line of code must be moved to the Content class
        

    }
}