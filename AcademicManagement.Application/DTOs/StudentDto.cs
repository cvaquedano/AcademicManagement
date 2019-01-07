using AcademicManagement.Application.DTOs.Core;
using System;

namespace AcademicManagement.Application.DTOs
{
    public class StudentDto:PersonDto
    {
        public int StudentId { get; set; }
       
        public bool IsRightHanded { get; set; }

        public string WriteWith {
            get {
                return IsRightHanded ? "Right Hand" : "Left Hand";
            }            
        }

        public int Age {
            get {
                int age = 0;               
                age = DateTime.Now.Year - BirthDate.Year;
                if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                    age = age - 1;
                return age;
            }
        }


    }
}
