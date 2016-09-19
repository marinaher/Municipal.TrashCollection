using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class Route
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.PostalCode)]
        [Display(Name = "Route Zip Code")]
        public int RouteZipCode { get; set; }

        [ForeignKey("Address")]
        [Display(Name = "Address ID")]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
    }
}