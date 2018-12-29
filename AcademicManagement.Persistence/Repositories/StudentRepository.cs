using AcademicManagement.Domain.Entities;
using AcademicManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Student item)
        {
            _context.Students.Add(item);
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student GetById(int Id)
        {
            return _context.Students.FirstOrDefault(s => s.StudentId == Id);
        }
    }
}
