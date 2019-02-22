using AcademicManagement.Domain.Core;
using AcademicManagement.Domain.Repository;
using AcademicManagement.Persistence.Repositories;

namespace AcademicManagement.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IStudentRepository Students { get; private set; }
        public ITeacherRepository Teachers { get; private set; }
        public IAsignatureRepository Asignatures { get; private set; }

        public ICourseRepository Courses { get; private set; }
        public ICourseDetailsRepository CourseDetails { get; private set; }

        public IAcademicPeriodRepository AcademicPeriod { get; private set; }

        public IAcademicPeriodDetailRepository AcademicPeriodDetail { get; private set; }

        public IAcademicPeriodCourseAsignatureRepository AcademicPeriodCourseAsignature { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new StudentRepository(context);
            Teachers = new TeacherRepository(context);
            Asignatures = new AsignatureRepository(context);
            Courses = new CourseRepository(context);
            CourseDetails = new CourseDetailsRepository(context);

            Courses = new CourseRepository(context);
            CourseDetails = new CourseDetailsRepository(context);
            AcademicPeriod = new AcademicPeriodRepository(context);
            AcademicPeriodDetail = new AcademicPeriodDetailRepository(context);
            AcademicPeriodCourseAsignature = new AcademicPeriodCourseAsignatureRepository(context);

        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
