namespace AcademicManagement.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAsignatureTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asignatures",
                c => new
                    {
                        AsignatureId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AsignatureId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Asignatures");
        }
    }
}
