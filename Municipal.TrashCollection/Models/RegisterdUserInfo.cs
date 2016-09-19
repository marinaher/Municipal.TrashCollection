using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class RegisterdUserInfo
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Monthly Bill")]
        public double MonthlyBill { get; set; }
    }
}