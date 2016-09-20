namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmigrations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserRole");
            DropColumn("dbo.RegisterdUserInfoes", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisterdUserInfoes", "UserId", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
        }
    }
}
