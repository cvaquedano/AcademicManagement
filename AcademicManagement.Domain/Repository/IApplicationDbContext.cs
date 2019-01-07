using AcademicManagement.Domain.Entities;
using System.Data.Entity;

namespace AcademicManagement.Domain.Repository
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Asignature> Asignatures { get; set; }
    }
}
