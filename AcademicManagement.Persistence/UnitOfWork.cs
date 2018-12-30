using AcademicManagement.Domain.Core;
using AcademicManagement.Domain.Repository;
using AcademicManagement.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStudentRepository Students { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new StudentRepository(context);

        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
