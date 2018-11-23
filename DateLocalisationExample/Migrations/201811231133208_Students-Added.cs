namespace DateLocalisationExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentNumber = c.String(nullable: false, maxLength: 128),
                        Firstname = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.StudentNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
        }
    }
}
