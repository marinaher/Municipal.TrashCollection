namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "CollectionID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "RouteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "CompanyID");
            CreateIndex("dbo.Employees", "CollectionID");
            CreateIndex("dbo.Employees", "RouteID");
            AddForeignKey("dbo.Employees", "CollectionID", "dbo.Collections", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "CompanyID", "dbo.Companies", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "RouteID", "dbo.Routes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "RouteID", "dbo.Routes");
            DropForeignKey("dbo.Employees", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Employees", "CollectionID", "dbo.Collections");
            DropIndex("dbo.Employees", new[] { "RouteID" });
            DropIndex("dbo.Employees", new[] { "CollectionID" });
            DropIndex("dbo.Employees", new[] { "CompanyID" });
            DropColumn("dbo.Employees", "RouteID");
            DropColumn("dbo.Employees", "CollectionID");
            DropColumn("dbo.Employees", "CompanyID");
        }
    }
}
