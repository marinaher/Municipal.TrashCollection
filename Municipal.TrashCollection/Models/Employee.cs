﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int RouteNumber { get; set; }
    }
}