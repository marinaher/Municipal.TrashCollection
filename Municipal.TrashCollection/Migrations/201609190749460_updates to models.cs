namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestomodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterdUserInfoes", "onVacation", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "RegisterdUserInfo_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "RegisterdUserInfo_id");
            AddForeignKey("dbo.AspNetUsers", "RegisterdUserInfo_id", "dbo.RegisterdUserInfoes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "RegisterdUserInfo_id", "dbo.RegisterdUserInfoes");
            DropIndex("dbo.AspNetUsers", new[] { "RegisterdUserInfo_id" });
            DropColumn("dbo.AspNetUsers", "RegisterdUserInfo_id");
            DropColumn("dbo.RegisterdUserInfoes", "onVacation");
        }
    }
}
