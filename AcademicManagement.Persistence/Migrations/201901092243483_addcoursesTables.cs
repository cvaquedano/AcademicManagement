namespace AcademicManagement.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcoursesTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseDetails",
                c => new
                    {
                        CourseDetailId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        AsignatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseDetailId)
                .ForeignKey("dbo.Asignatures", t => t.AsignatureId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.AsignatureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseDetails", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseDetails", "AsignatureId", "dbo.Asignatures");
            DropIndex("dbo.CourseDetails", new[] { "AsignatureId" });
            DropIndex("dbo.CourseDetails", new[] { "CourseId" });
            DropTable("dbo.CourseDetails");
            DropTable("dbo.Courses");
        }
    }
}
