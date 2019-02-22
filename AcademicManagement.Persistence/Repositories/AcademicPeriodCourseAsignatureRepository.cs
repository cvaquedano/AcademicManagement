using AcademicManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Persistence.Repositories
{
    public class AcademicPeriodCourseAsignatureRepository: IAcademicPeriodCourseAsignatureRepository
    {

        private readonly IApplicationDbContext _context;

        public AcademicPeriodCourseAsignatureRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
