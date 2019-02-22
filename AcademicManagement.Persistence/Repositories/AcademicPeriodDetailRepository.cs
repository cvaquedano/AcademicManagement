using AcademicManagement.Domain.Entities.AcademicPeriods;
using AcademicManagement.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AcademicManagement.Persistence.Repositories
{
    public class AcademicPeriodDetailRepository : IAcademicPeriodDetailRepository
    {
        private readonly IApplicationDbContext _context;

        public AcademicPeriodDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(AcademicPeriodDetail item)
        {
            _context.AcademicPeriodDetails.Add(item);
        }

        public void Delete(AcademicPeriodDetail item)
        {
            _context.AcademicPeriodDetails.Remove(item);
        }

        public IEnumerable<AcademicPeriodDetail> Find(string query)
        {
            return _context.AcademicPeriodDetails.Where(a => a.Section.Contains(query) || a.CourseName.Contains(query));
        }

        public IEnumerable<AcademicPeriodDetail> GetAll()
        {
            return _context.AcademicPeriodDetails;
        }

        public AcademicPeriodDetail GetById(int id)
        {
            return _context.AcademicPeriodDetails
             
                .FirstOrDefault(a => a.AcademicPeriodDetailId == id);
        }


    }
}
