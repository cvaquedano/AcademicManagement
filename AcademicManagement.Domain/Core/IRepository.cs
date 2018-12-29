using System.Collections.Generic;

namespace AcademicManagement.Domain.Core
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Add(T item);
        void Delete(T item);
        IUnitOfWork UnitOfWork { get; }
    }
}
