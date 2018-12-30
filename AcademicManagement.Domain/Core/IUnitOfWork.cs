using AcademicManagement.Domain.Repository;

namespace AcademicManagement.Domain.Core
{
    public interface IUnitOfWork
    {
        ITeacherRepository Teachers { get; }
        IStudentRepository Students { get; }
      

        void Commit();
    }
}
