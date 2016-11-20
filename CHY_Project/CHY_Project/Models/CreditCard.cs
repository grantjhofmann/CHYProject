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
        public Int32 CardNumber { get; set; }

        [Required]
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