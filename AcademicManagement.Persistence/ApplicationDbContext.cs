using AcademicManagement.Domain.Entities;
using AcademicManagement.Domain.Entities.Courses;
using AcademicManagement.Domain.Repository;
using System.Data.Entity;

namespace AcademicManagement.Persistence
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get ; set; }
        public DbSet<Asignature> Asignatures { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }

        public ApplicationDbContext() : base("AcademicManagementConnection")
        {

        }       

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
