using System.Collections.Generic;

namespace AcademicManagement.Domain.Core
{
    public interface IRepository<T>
    {
        IEnumerable<T> Find(string query);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Delete(T item);


    }
}
