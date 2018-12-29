using AcademicManagement.Domain.Repository;

namespace AcademicManagement.Domain.Core
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }

        void Commit();
    }
}
