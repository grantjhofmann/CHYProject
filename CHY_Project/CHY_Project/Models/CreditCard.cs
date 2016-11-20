using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CHY_Project.Models
{
    public class CreditCard
    {
        public Int32 CreditCardID { get; set; }

        public Int32 CardNumber { get; set; }

        public virtual AppUser Customer { get; set; }

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