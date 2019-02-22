using AcademicManagement.Domain.Entities.Courses;
using AcademicManagement.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AcademicManagement.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Course item)
        {
            _context.Courses.Add(item);
        }

        public void Delete(Course item)
        {
            _context.Courses.Remove(item);
        }

        public IEnumerable<Course> Find(string query)
        {
            return _context.Courses.Where(a => a.Name.Contains(query) || a.Description.Contains(query));
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.Include(detail=>detail.CourseDetails.Select(a=>a.Asignature));
        }

        public Course GetById(int id)
        {
            return _context.Courses
                .Include(detail => detail.CourseDetails.Select(a => a.Asignature))
                .FirstOrDefault(a => a.CourseId == id);
        }

      
    }
}
