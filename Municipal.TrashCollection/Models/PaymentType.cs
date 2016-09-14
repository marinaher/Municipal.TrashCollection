using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class PaymentType
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("CreditCard")]
        public int CreditCard_ID { get; set; }
        public virtual CreditCard CreditCard { get; set; }

        [ForeignKey("PayPal")]
        public int PayPal_ID { get; set; }
        public virtual PayPal PayPal { get; set; }

        public int TotalAmount { get; set; }
    }
}