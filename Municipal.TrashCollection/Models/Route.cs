using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class Route
    {
        [Key]
        public int ID { get; set; }
        public int RouteZipCode { get; set; }
    }
}