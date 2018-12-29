using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Application.DTOs
{
    public class StudentDto:BaseDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Genre { get; set; }
        public bool IsRightHanded { get; set; }

       
    }
}
