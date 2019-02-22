using AcademicManagement.Domain.Repository;

namespace AcademicManagement.Domain.Core
{
    public interface IUnitOfWork
    {
        ITeacherRepository Teachers { get; }
        IStudentRepository Students { get; }
        IAsignatureRepository Asignatures { get; }
        ICourseRepository Courses { get; }
        ICourseDetailsRepository CourseDetails { get; }

        IAcademicPeriodRepository AcademicPeriod { get; }
        IAcademicPeriodDetailRepository AcademicPeriodDetail { get; }
        IAcademicPeriodCourseAsignatureRepository AcademicPeriodCourseAsignature { get; }


        void Commit();
    }
}
