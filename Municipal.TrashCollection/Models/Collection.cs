using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class Collection
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal ServiceCost { get; set; }
        public decimal TotalServiceCost { get; set; }
    }
}