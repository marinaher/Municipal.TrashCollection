using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Municipal.TrashCollection.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [ForeignKey("Employee")]
        [Display(Name = "Employee ID")]
        public int? Employee_id { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Address")]
        [Display(Name = "Address ID")]
        public int? Address_id { get; set; }
        public virtual Address Address { get; set; }

        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set; }  //day of week


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public class ApplicationUser : IdentityUser { public DateTime BirthDate { get; set; } };
        public DbSet<Calendar> calendar { get; set; }
        public DbSet <Employee> employee { get; set; }
        public DbSet <Route> route { get; set; }
        public DbSet<Address> address { get; set; }
        public DbSet<RegisterdUserInfo> RegisterdUserInfoes { get; set; }
    }
}