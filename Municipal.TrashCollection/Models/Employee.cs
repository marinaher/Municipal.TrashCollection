using System;
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

        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [ForeignKey("Route")]
        [Display(Name = "Route ID")]
        public int RouteID { get; set; }
        public virtual Route Route { get; set; }
    }
}