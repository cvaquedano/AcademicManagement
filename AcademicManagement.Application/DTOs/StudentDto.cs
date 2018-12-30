using AcademicManagement.Application.DTOs.Core;

namespace AcademicManagement.Application.DTOs
{
    public class StudentDto:PersonDto
    {
        public int StudentId { get; set; }
       
        public bool IsRightHanded { get; set; }


    }
}
