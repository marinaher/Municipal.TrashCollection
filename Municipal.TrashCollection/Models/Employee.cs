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
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Collection")]
        public int CollectionID { get; set; }
        public virtual Collection Collection { get; set; }

        [ForeignKey("Route")]
        public int RouteID { get; set; }
        public virtual Route Route { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ResetPassword { get; set; }
    }
}