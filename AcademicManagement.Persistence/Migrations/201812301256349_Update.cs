namespace AcademicManagement.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FirstName", c => c.String());
            DropColumn("dbo.Students", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Name", c => c.String());
            DropColumn("dbo.Students", "FirstName");
        }
    }
}
