using AcademicManagement.Application.DTOs;
using System.Collections.Generic;

namespace AcademicManagement.Application.Services.Students
{
    public interface IStudentAppService
    {
        List<StudentDto> GetStudents();
        StudentDto GetStudentById(int id);
        StudentDto CreateStudent(StudentDto student);

        StudentDto UpdateStudent(StudentDto student);
        StudentDto DeleteStudent(int id);


    }
}
