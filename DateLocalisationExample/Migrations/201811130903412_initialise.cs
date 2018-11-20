namespace DateLocalisationExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocalDates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LocalDates");
        }
    }
}
