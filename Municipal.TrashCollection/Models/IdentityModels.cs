﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Municipal.TrashCollection.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Address")]
        public int? Address_id { get; set; }
        public virtual Address Address { get; set; }


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
        public DbSet <Collection> collection { get; set; }
        public DbSet <Collection_Calendar> collection_Calendar{ get; set; }
        public DbSet <Employee> employee { get; set; }
        public DbSet <Route> route { get; set; }
        public DbSet<PayPal> payPal { get; set; }
        public DbSet<Address> address { get; set; }
        public DbSet<CreditCard> creditCard { get; set; }
        public DbSet<PaymentType> paymentType { get; set; }

    }
}