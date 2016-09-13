using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class Company
    {
        [Key]
        public int ID { get; set; }

        //[ForeignKey("Address")]
        //public int AddressID { get; set; }
        //public virtual Address Address {get; set;}

        public string Name { get; set; }
    }
}