using AcademicManagement.Application.DTOs;
using AcademicManagement.Domain.Core;
using AcademicManagement.Domain.Entities;
using AcademicManagement.Persistence;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AcademicManagement.Application.Services.Students
{
    public class StudentAppService: IStudentAppService
    {
        private readonly IUnitOfWork _unitOfWork;


        public StudentAppService()
        {
            var context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(context);
        }

       

        private void Commit()
        {
            _unitOfWork.Commit();
        }

        public StudentDto CreateStudent(StudentDto student)
        {
            var newStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                Gender = student.Gender,
                IsRightHanded = student.IsRightHanded
            };
            _unitOfWork.Students.Add(newStudent);

            student.StudentId = newStudent.StudentId;

            Commit();
            return student;
        }

        public StudentDto DeleteStudent(int id)
        {
            var student= _unitOfWork.Students.GetById(id);
            var studentDto = new StudentDto();

            if (student == null)
            {
                //studentDto.ErrorMessage = "Student not found";
                return studentDto;
            }
             _unitOfWork.Students.Delete(student);
            Commit();
            return studentDto;
        }

        public StudentDto GetStudentById(int id)
        {
            var student =  _unitOfWork.Students.GetById(id);
            var studentDto = new StudentDto();
            if (student == null)
            {
                //studentDto.ErrorMessage = "Student not Found";
                return studentDto;
            }

            return Mapper.Map<Student, StudentDto>(student);

        }

        public List<StudentDto> GetStudents()
        {
            var students= _unitOfWork.Students.GetAll().ToList();
          

            return Mapper.Map<List<Student>, List<StudentDto>>(students);

        }

        public StudentDto UpdateStudent(int id,StudentDto student)
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
            Commit();

            return student;
        }
    }
}
