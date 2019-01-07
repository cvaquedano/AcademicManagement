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

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new StudentRepository(context);
            Teachers = new TeacherRepository(context);
            Asignatures = new AsignatureRepository(context);

        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
