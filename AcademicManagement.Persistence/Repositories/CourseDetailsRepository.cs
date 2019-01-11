using AcademicManagement.Domain.Entities.Courses;
using AcademicManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Persistence.Repositories
{
    public class CourseDetailsRepository : ICourseDetailsRepository
    {
        private readonly IApplicationDbContext _context;

        public CourseDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CourseDetail item)
        {
            _context.CourseDetails.Add(item);
        }

        public void Delete(CourseDetail item)
        {
            _context.CourseDetails.Remove(item);
        }

        public IEnumerable<CourseDetail> Find(string query)
        {
            return null;// _context.CourseDetails.Where(a => a.Name.Contains(query) || a.Description.Contains(query));
        }

        public IEnumerable<CourseDetail> GetAll()
        {
            return _context.CourseDetails;
        }

        public CourseDetail GetById(int id)
        {
            return _context.CourseDetails.FirstOrDefault(a => a.CourseDetailId == id);
        }


    }
}
