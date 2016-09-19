namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class majorupdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Collection_Calendar", "CalendarID", "dbo.Calendars");
            DropForeignKey("dbo.Collection_Calendar", "CollectionID", "dbo.Collections");
            DropForeignKey("dbo.Employees", "CollectionID", "dbo.Collections");
            DropForeignKey("dbo.PaymentTypes", "CreditCard_ID", "dbo.CreditCards");
            DropForeignKey("dbo.PaymentTypes", "PayPal_ID", "dbo.PayPals");
            DropIndex("dbo.Collection_Calendar", new[] { "CollectionID" });
            DropIndex("dbo.Collection_Calendar", new[] { "CalendarID" });
            DropIndex("dbo.Employees", new[] { "CollectionID" });
            DropIndex("dbo.PaymentTypes", new[] { "CreditCard_ID" });
            DropIndex("dbo.PaymentTypes", new[] { "PayPal_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Employee_ID" });
            AddColumn("dbo.Calendars", "StartDate", c => c.DateTime());
            AddColumn("dbo.Calendars", "EndDate", c => c.DateTime());
            AddColumn("dbo.Routes", "AddressID", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "PickupDay", c => c.String());
            AlterColumn("dbo.Addresses", "State", c => c.String(maxLength: 2));
            CreateIndex("dbo.Routes", "AddressID");
            CreateIndex("dbo.AspNetUsers", "Employee_id");
            AddForeignKey("dbo.Routes", "AddressID", "dbo.Addresses", "ID", cascadeDelete: true);
            DropColumn("dbo.Calendars", "Week");
            DropColumn("dbo.Calendars", "Month");
            DropColumn("dbo.Employees", "FirstName");
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "DOB");
            DropColumn("dbo.Employees", "CollectionID");
            DropColumn("dbo.Employees", "UserName");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "ResetPassword");
            DropColumn("dbo.RegisterdUserInfoes", "AnnualBill");
            DropColumn("dbo.RegisterdUserInfoes", "TotalBill");
            DropTable("dbo.Collections");
            DropTable("dbo.Collection_Calendar");
            DropTable("dbo.CreditCards");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.PayPals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PayPals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreditCard_ID = c.Int(nullable: false),
                        PayPal_ID = c.Int(nullable: false),
                        TotalAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.Collection_Calendar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CollectionID = c.Int(nullable: false),
                        CalendarID = c.Int(nullable: false),
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
            
            AddColumn("dbo.RegisterdUserInfoes", "TotalBill", c => c.Double(nullable: false));
            AddColumn("dbo.RegisterdUserInfoes", "AnnualBill", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "ResetPassword", c => c.String());
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Employees", "UserName", c => c.String());
            AddColumn("dbo.Employees", "CollectionID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "LastName", c => c.String());
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            AddColumn("dbo.Calendars", "Month", c => c.DateTime(nullable: false));
            AddColumn("dbo.Calendars", "Week", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Routes", "AddressID", "dbo.Addresses");
            DropIndex("dbo.AspNetUsers", new[] { "Employee_id" });
            DropIndex("dbo.Routes", new[] { "AddressID" });
            AlterColumn("dbo.Addresses", "State", c => c.String());
            DropColumn("dbo.AspNetUsers", "PickupDay");
            DropColumn("dbo.Routes", "AddressID");
            DropColumn("dbo.Calendars", "EndDate");
            DropColumn("dbo.Calendars", "StartDate");
            CreateIndex("dbo.AspNetUsers", "Employee_ID");
            CreateIndex("dbo.PaymentTypes", "PayPal_ID");
            CreateIndex("dbo.PaymentTypes", "CreditCard_ID");
            CreateIndex("dbo.Employees", "CollectionID");
            CreateIndex("dbo.Collection_Calendar", "CalendarID");
            CreateIndex("dbo.Collection_Calendar", "CollectionID");
            AddForeignKey("dbo.PaymentTypes", "PayPal_ID", "dbo.PayPals", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PaymentTypes", "CreditCard_ID", "dbo.CreditCards", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "CollectionID", "dbo.Collections", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Collection_Calendar", "CollectionID", "dbo.Collections", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Collection_Calendar", "CalendarID", "dbo.Calendars", "ID", cascadeDelete: true);
        }
    }
}
