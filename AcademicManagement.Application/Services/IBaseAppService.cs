using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
