namespace AcademicManagement.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAcademicPeriodTablle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicPeriodDetails",
                c => new
                    {
                        AcademicPeriodDetailId = c.Int(nullable: false, identity: true),
                        AcademicPeriodId = c.Int(nullable: false),
                        Section = c.String(),
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.AcademicPeriodDetailId)
                .ForeignKey("dbo.AcademicPeriods", t => t.AcademicPeriodId, cascadeDelete: true)
                .Index(t => t.AcademicPeriodId);
            
            CreateTable(
                "dbo.AcademicPeriods",
                c => new
                    {
                        AcademicPeriodId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.AcademicPeriodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcademicPeriodDetails", "AcademicPeriodId", "dbo.AcademicPeriods");
            DropIndex("dbo.AcademicPeriodDetails", new[] { "AcademicPeriodId" });
            DropTable("dbo.AcademicPeriods");
            DropTable("dbo.AcademicPeriodDetails");
        }
    }
}
