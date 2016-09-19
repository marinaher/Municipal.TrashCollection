namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtopickupdayscontrller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickUpDays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        Status = c.Boolean(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: false)
                .Index(t => t.EmployeeID)
                .Index(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickUpDays", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.PickUpDays", "AddressID", "dbo.Addresses");
            DropIndex("dbo.PickUpDays", new[] { "AddressID" });
            DropIndex("dbo.PickUpDays", new[] { "EmployeeID" });
            DropTable("dbo.PickUpDays");
        }
    }
}
