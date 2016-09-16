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
        public string PickupDay { get; set; }
        public double MonthlyBill { get; set; }
        public double AnnualBill { get; set; }
        public double TotalBill { get; set; }
    }
}