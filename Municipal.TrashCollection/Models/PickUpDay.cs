using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Municipal.TrashCollection.Models
{
    public class PickUpDay
    {
        [Key]
        public int ID { get; set; }
        public string Day { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public bool Status { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public Address Address { get; set; }

        public IEnumerable<SelectListItem> Days { get; set; }
    }
}