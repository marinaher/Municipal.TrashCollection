namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Birthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ResetPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ResetPassword");
        }
    }
}
