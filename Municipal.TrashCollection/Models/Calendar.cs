using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class Calendar
    {
        [Key]
        public int ID { get; set; }
        public DateTime Week { get; set; }
        public DateTime Month { get; set; }
    }
}