namespace Municipal.TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class majorupdates : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Calendars");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
