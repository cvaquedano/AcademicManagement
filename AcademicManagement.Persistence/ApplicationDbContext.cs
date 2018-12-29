using AcademicManagement.Domain.Entities;
using AcademicManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Persistence
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public DbSet<Student> Students { get; set; }

        public ApplicationDbContext() : base("AcademicManagementConnection")
        {

        }       

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
