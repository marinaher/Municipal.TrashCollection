namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbsetaddedkeyforcollection_calendar : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
               "dbo.Routes",
               c => new
               {
                   ID = c.Int(nullable: false, identity: true),
                   RouteZipCode = c.Int(nullable: false),
                   AddressID = c.Int(nullable: false),
               })
               .PrimaryKey(t => t.ID)
               .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: false)
               .Index(t => t.AddressID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collection_Calendar", "CollectionID", "dbo.Collections");
            DropForeignKey("dbo.Collection_Calendar", "CalendarID", "dbo.Calendars");
            DropIndex("dbo.Collection_Calendar", new[] { "CalendarID" });
            DropIndex("dbo.Collection_Calendar", new[] { "CollectionID" });
            DropTable("dbo.Routes");
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
            DropTable("dbo.Collection_Calendar");
            DropTable("dbo.Collections");
            DropTable("dbo.Calendars");
        }
    }
}
