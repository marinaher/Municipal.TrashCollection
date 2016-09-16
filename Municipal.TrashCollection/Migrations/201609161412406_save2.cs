namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class save2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterdUserInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PickupDay = c.String(),
                        MonthlyBill = c.Double(nullable: false),
                        AnnualBill = c.Double(nullable: false),
                        TotalBill = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisterdUserInfoes");
        }
    }
}
