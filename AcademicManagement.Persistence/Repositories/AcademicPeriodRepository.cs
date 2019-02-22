using AcademicManagement.Domain.Entities.AcademicPeriods;
using AcademicManagement.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AcademicManagement.Persistence.Repositories
{
    public class AcademicPeriodRepository : IAcademicPeriodRepository
    {
        private readonly IApplicationDbContext _context;

        public AcademicPeriodRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(AcademicPeriod item)
        {
            _context.AcademicPeriods.Add(item);
        }

        public void Delete(AcademicPeriod item)
        {
            _context.AcademicPeriods.Remove(item);
        }

        public IEnumerable<AcademicPeriod> Find(string query)
        {
            return _context.AcademicPeriods
                .Where(a => a.Name.Contains(query) || a.Description.Contains(query))
                .Include(t=>t.AcademicPeriodDetail);
        }

        public IEnumerable<AcademicPeriod> GetAll()
        {
            return _context.AcademicPeriods.Include(detail => detail.AcademicPeriodDetail);
        }

        public AcademicPeriod GetById(int id)
        {
            return _context.AcademicPeriods
               .Include(detail => detail.AcademicPeriodDetail)
                .FirstOrDefault(a => a.AcademicPeriodId == id);
        }


    }
}
