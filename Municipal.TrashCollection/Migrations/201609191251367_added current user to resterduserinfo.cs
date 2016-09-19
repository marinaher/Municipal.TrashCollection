namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcurrentusertoresterduserinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterdUserInfoes", "currentUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.RegisterdUserInfoes", "currentUser_Id");
            AddForeignKey("dbo.RegisterdUserInfoes", "currentUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisterdUserInfoes", "currentUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RegisterdUserInfoes", new[] { "currentUser_Id" });
            DropColumn("dbo.RegisterdUserInfoes", "currentUser_Id");
        }
    }
}
