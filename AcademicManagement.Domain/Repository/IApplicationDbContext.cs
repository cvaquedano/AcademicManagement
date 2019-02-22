using AcademicManagement.Domain.Entities;
using AcademicManagement.Domain.Entities.AcademicPeriods;
using AcademicManagement.Domain.Entities.Courses;
using System.Data.Entity;

namespace AcademicManagement.Domain.Repository
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Asignature> Asignatures { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<CourseDetail> CourseDetails { get; set; }

        DbSet<AcademicPeriod> AcademicPeriods { get; set; }
        DbSet<AcademicPeriodDetail> AcademicPeriodDetails { get; set; }
        DbSet<AcademicPeriodCourseAsignature> AcademicPeriodCourseAsignatures { get; set; }
    }
}
