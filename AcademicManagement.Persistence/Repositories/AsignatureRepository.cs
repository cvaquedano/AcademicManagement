using AcademicManagement.Domain.Entities;
using AcademicManagement.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AcademicManagement.Persistence.Repositories
{
    public class AsignatureRepository : IAsignatureRepository
    {
        private readonly IApplicationDbContext _context;

        public AsignatureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Asignature item)
        {
            _context.Asignatures.Add(item);
        }

        public void Delete(Asignature item)
        {
            _context.Asignatures.Remove(item);
        }

        public IEnumerable<Asignature> Find(string query)
        {
            return _context.Asignatures.Where(a => a.Name.Contains(query) || a.Description.Contains(query));
        }

        public IEnumerable<Asignature> GetAll()
        {
            return _context.Asignatures;
        }

        public Asignature GetById(int id)
        {
            return _context.Asignatures.FirstOrDefault(a => a.AsignatureId == id);
        }
    }
}
