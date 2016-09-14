namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedadditionaldbset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApartmentNumber = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentTypes", "PayPal_ID", "dbo.PayPals");
            DropForeignKey("dbo.PaymentTypes", "CreditCard_ID", "dbo.CreditCards");
            DropIndex("dbo.PaymentTypes", new[] { "PayPal_ID" });
            DropIndex("dbo.PaymentTypes", new[] { "CreditCard_ID" });
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Addresses");
        }
    }
}
