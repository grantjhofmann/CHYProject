using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class CheckoutViewModel
    {

        public String CardNumber { get; set; }
        public List<Product> Products { get; set; }

        [Display (Name = "Is this a gift for someone? If so, check yes and give the recipient's email address below:")]
        public Boolean Gift { get; set; }


        [EmailAddress (ErrorMessage = "Enter a valid email address.")]
        [Display (Name = "Recipient Email Address")]
        public String RecipientEmail { get; set; }
    }
}