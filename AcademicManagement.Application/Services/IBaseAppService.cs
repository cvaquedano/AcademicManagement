using System.Collections.Generic;

namespace AcademicManagement.Application.Services
{
    public interface IBaseAppService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T item);
        T Update(int id, T item);
        T Delete(int id);
        List<T> Find(string query);
    }
}
