using System;

namespace AcademicManagement.Domain.Entities.BaseEntities
{
    public class Person
    {
       
        public string Name { get; set; }
       
        public string LastName { get; set; }
      
        public DateTime BirthDate { get; set; }

        public bool Gender { get; set; }

        public string NombreCompleto()
        {
            return Name + " " + LastName;
        }
    }
}
