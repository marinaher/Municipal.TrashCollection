namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtoregistration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address_id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Employee_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Address_id");
            CreateIndex("dbo.AspNetUsers", "Employee_ID");
            AddForeignKey("dbo.AspNetUsers", "Address_id", "dbo.Addresses", "ID");
            AddForeignKey("dbo.AspNetUsers", "Employee_ID", "dbo.Employees", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.AspNetUsers", "Address_id", "dbo.Addresses");
            DropIndex("dbo.AspNetUsers", new[] { "Employee_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Address_id" });
            DropColumn("dbo.AspNetUsers", "Employee_ID");
            DropColumn("dbo.AspNetUsers", "Address_id");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
