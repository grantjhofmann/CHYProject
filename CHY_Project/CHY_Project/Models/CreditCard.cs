using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHY_Project.Models
{
    public class CreditCard
    {
        public Int32 CreditCardID { get; set; }

        [Required]
        public String CardNumber { get; set; }

        
        public virtual AppUser Customer { get; set; }

        [Required]
        public Cardtype Cardtype { get; set; }
    }
    public enum Cardtype
    {
        Visa,
        MasterCard,
        AmericanExpress,
        Discover
    }
}