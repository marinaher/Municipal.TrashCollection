namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadetruechngedtofalse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "RouteID", "dbo.Routes");
            DropForeignKey("dbo.AspNetUsers", "Employee_id", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "RouteID" });
            DropIndex("dbo.AspNetUsers", new[] { "Employee_id" });
            AddColumn("dbo.Employees", "UserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "RouteNumber", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "UserID");
            AddForeignKey("dbo.Employees", "UserID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Employees", "EmployeeID");
            DropColumn("dbo.Employees", "IsActive");
            DropColumn("dbo.Employees", "RouteID");
            DropColumn("dbo.AspNetUsers", "Employee_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Employee_id", c => c.Int());
            AddColumn("dbo.Employees", "RouteID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "UserID" });
            DropColumn("dbo.Employees", "RouteNumber");
            DropColumn("dbo.Employees", "UserID");
            CreateIndex("dbo.AspNetUsers", "Employee_id");
            CreateIndex("dbo.Employees", "RouteID");
            AddForeignKey("dbo.AspNetUsers", "Employee_id", "dbo.Employees", "ID");
            AddForeignKey("dbo.Employees", "RouteID", "dbo.Routes", "ID", cascadeDelete: true);
        }
    }
}
