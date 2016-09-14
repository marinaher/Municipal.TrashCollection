namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstreettoaddressclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Street", c => c.String());
            AddColumn("dbo.Companies", "AddressID", c => c.Int(nullable: false));
            AddColumn("dbo.Routes", "AddressID", c => c.Int(nullable: false));
            CreateIndex("dbo.Companies", "AddressID");
            CreateIndex("dbo.Routes", "AddressID");
            AddForeignKey("dbo.Companies", "AddressID", "dbo.Addresses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Routes", "AddressID", "dbo.Addresses", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Companies", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Routes", new[] { "AddressID" });
            DropIndex("dbo.Companies", new[] { "AddressID" });
            DropColumn("dbo.Routes", "AddressID");
            DropColumn("dbo.Companies", "AddressID");
            DropColumn("dbo.Addresses", "Street");
        }
    }
}
