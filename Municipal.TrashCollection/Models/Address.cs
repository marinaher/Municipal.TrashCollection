using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string Street { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Apt No.")]
        public string ApartmentNumber { get; set; }
        public string City { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2)]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
    }
}