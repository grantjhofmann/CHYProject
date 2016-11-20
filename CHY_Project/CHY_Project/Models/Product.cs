using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHY_Project.Models
{
    public class Product : Content
    {
        public Int32 ProductID { get; set; }

        [Required]
        public Decimal RegularPrice { get; set; }

        public Decimal DiscountPrice { get; set; }

        //NOTE: Can artists be featured? If so, this line of code must be moved to the Content class
        public Boolean Featured { get; set; }

    }
}