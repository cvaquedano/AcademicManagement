using AcademicManagement.Domain.Entities;
using AcademicManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Persistence.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Teacher item)
        {
            _context.Teachers.Add(item);
        }

        public void Delete(Teacher item)
        {
            _context.Teachers.Remove(item);
        }

        public IEnumerable<Teacher> Find(string query)
        {
            return _context.Teachers.Where(t => t.FirstName.Contains(query) || t.LastName.Contains(query));
            
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers;
        }

        public Teacher GetById(int id)
        {
            return _context.Teachers.FirstOrDefault(t => t.TeacherId == id);
        }
    }
}
