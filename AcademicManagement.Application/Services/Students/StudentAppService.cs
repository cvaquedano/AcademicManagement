using AcademicManagement.Application.DTOs;
using AcademicManagement.Domain.Core;
using AcademicManagement.Domain.Entities;

using System.Collections.Generic;
using System.Linq;

namespace AcademicManagement.Application.Services.Students
{
    public class StudentAppService: IStudentAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       

        public StudentDto Create(StudentDto item)
        {
            var newStudent = new Student
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                BirthDate = item.BirthDate,
                Gender = item.Gender,
                IsRightHanded = item.IsRightHanded
            };
            _unitOfWork.Students.Add(newStudent);           

            _unitOfWork.Commit();
            item.StudentId = newStudent.StudentId;
            return item;
        }

        public StudentDto Delete(int id)
        {
            var student= _unitOfWork.Students.GetById(id);
            var studentDto = new StudentDto { StudentId=id};

            if (student == null)
            {
                studentDto.ErrorMessage = "Student not found";
                return null;
            }
             _unitOfWork.Students.Delete(student);
            _unitOfWork.Commit();
            return studentDto;
        }

        public StudentDto GetById(int id)
        {
            var student =  _unitOfWork.Students.GetById(id);
            var studentDto = new StudentDto();
            if (student == null)
            {
                studentDto.ErrorMessage = "Student not Found";
                return studentDto;
            }

            return MapStudentEntitiveToDto(student);

        }

        public List<StudentDto> GetAll()
        {
            var students= _unitOfWork.Students.GetAll().ToList();
          

            return MapStudentEntitiveToDto(students);

        }

        public StudentDto Update(int id,StudentDto student)
        {
            var studentOnDB =  _unitOfWork.Students.GetById(id);

            if (studentOnDB == null)
            {
                //student.ErrorMessage = "StudentNotFound";
                return student;
            }
            studentOnDB.FirstName = student.FirstName;
            studentOnDB.LastName = student.LastName;
            studentOnDB.BirthDate = student.BirthDate;
            studentOnDB.Gender = student.Gender;
            studentOnDB.IsRightHanded = student.IsRightHanded;

            _unitOfWork.Commit();

            return student;
        }

        public List<StudentDto> Find(string query)
        {
            var students = _unitOfWork.Students.Find(query).ToList();
            return MapStudentEntitiveToDto(students);
        }




        private static List<StudentDto> MapStudentEntitiveToDto(List<Student> students)
        {
            //List<StudentDto> result = new List<StudentDto>();

            //students.Select(student => new StudentDto(student.FirstName, student.LastName, student.BirthDate, student.Gender, student.IsRightHanded));
            //foreach (var student in students)
            //{
            //    var newItem = new StudentDto(student.FirstName, student.LastName, student.BirthDate, student.Gender, student.IsRightHanded);
                              
            //    result.Add(newItem);
            //}
            return students.Select(student => new StudentDto(student.StudentId, student.FirstName, student.LastName, student.BirthDate, student.Gender, student.IsRightHanded)).ToList(); 
        }

        private static StudentDto MapStudentEntitiveToDto(Student student)
        {
            var result = new StudentDto(student.StudentId, student.FirstName, student.LastName, student.BirthDate, student.Gender, student.IsRightHanded);

            return result;
        }

    }
}
