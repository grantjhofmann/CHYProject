using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHY_Project.Models
{
    public class Purchase : Cart
    {
        public String PurchaseID { get; set; }

        public virtual CreditCard CreditCard { get; set; }

        public Boolean Gift { get; set; }

        public virtual AppUser Recipient { get; set; }

        //NOTE: Do we need to store recommendation data?
        //public String Recommendation { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

        public DateTime Date { get; set; }
    }
}