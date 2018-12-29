using AcademicManagement.Domain.Entities.BaseEntities;

namespace AcademicManagement.Domain.Entities
{
    public class Student:Person
    {
        
        public int StudentId { get; set; }
       
        public bool IsRightHanded { get; set; }
    }
}
