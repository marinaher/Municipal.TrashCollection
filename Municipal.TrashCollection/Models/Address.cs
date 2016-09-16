﻿using System;
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

        [Display(Name = "Apt No.")]
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
    }
}