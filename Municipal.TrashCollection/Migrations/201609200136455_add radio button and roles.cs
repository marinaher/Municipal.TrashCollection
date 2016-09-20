namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addradiobuttonandroles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
            AddColumn("dbo.RegisterdUserInfoes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisterdUserInfoes", "UserId");
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
    }
}
