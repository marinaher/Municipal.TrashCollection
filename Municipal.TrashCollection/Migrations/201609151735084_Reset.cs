namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Street = c.String(),
                    ApartmentNumber = c.String(),
                    City = c.String(),
                    State = c.String(),
                    ZipCode = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Calendars",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Week = c.DateTime(nullable: false),
                    Month = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Collections",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    Time = c.DateTime(nullable: false),
                    ServiceCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TotalServiceCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Collection_Calendar",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    CollectionID = c.Int(nullable: false),
                    CalendarID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Calendars", t => t.CalendarID, cascadeDelete: true)
                .ForeignKey("dbo.Collections", t => t.CollectionID, cascadeDelete: true)
                .Index(t => t.CollectionID)
                .Index(t => t.CalendarID);

            CreateTable(
                "dbo.CreditCards",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    CardHolderName = c.String(),
                    CardNumber = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Employees",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    EmployeeID = c.Int(nullable: false),
                    FirstName = c.String(),
                    LastName = c.String(),
                    DOB = c.DateTime(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    CollectionID = c.Int(nullable: false),
                    RouteID = c.Int(nullable: false),
                    UserName = c.String(),
                    Password = c.String(),
                    ResetPassword = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Collections", t => t.CollectionID, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteID, cascadeDelete: true)
                .Index(t => t.CollectionID)
                .Index(t => t.RouteID);

            CreateTable(
                "dbo.Routes",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    RouteZipCode = c.Int(nullable: false),
                    AddressID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);

            CreateTable(
                "dbo.PaymentTypes",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    CreditCard_ID = c.Int(nullable: false),
                    PayPal_ID = c.Int(nullable: false),
                    TotalAmount = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_ID, cascadeDelete: true)
                .ForeignKey("dbo.PayPals", t => t.PayPal_ID, cascadeDelete: true)
                .Index(t => t.CreditCard_ID)
                .Index(t => t.PayPal_ID);

            CreateTable(
                "dbo.PayPals",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PaymentTypes", "PayPal_ID", "dbo.PayPals");
            DropForeignKey("dbo.PaymentTypes", "CreditCard_ID", "dbo.CreditCards");
            DropForeignKey("dbo.Employees", "RouteID", "dbo.Routes");
            DropForeignKey("dbo.Routes", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Employees", "CollectionID", "dbo.Collections");
            DropForeignKey("dbo.Collection_Calendar", "CollectionID", "dbo.Collections");
            DropForeignKey("dbo.Collection_Calendar", "CalendarID", "dbo.Calendars");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PaymentTypes", new[] { "PayPal_ID" });
            DropIndex("dbo.PaymentTypes", new[] { "CreditCard_ID" });
            DropIndex("dbo.Routes", new[] { "AddressID" });
            DropIndex("dbo.Employees", new[] { "RouteID" });
            DropIndex("dbo.Employees", new[] { "CollectionID" });
            DropIndex("dbo.Collection_Calendar", new[] { "CalendarID" });
            DropIndex("dbo.Collection_Calendar", new[] { "CollectionID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PayPals");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Routes");
            DropTable("dbo.Employees");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Collection_Calendar");
            DropTable("dbo.Collections");
            DropTable("dbo.Calendars");
            DropTable("dbo.Addresses");
        }
    }
}
