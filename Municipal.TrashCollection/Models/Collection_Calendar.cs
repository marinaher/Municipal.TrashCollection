using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class Collection_Calendar
    {
        [Key]
        public int ID { get; set; }
        
        [ForeignKey("Collection")]
        public int CollectionID { get; set; }
        public virtual Collection Collection { get; set; }

        [ForeignKey("Calendar")]
        public int CalendarID { get; set; }
        public virtual Calendar Calendar { get; set; }
    }
}