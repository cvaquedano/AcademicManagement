using System;

namespace AcademicManagement.Application.DTOs.Core
{
    public class PersonDto:BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
    }
}
