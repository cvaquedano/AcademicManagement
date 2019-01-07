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
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
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

            item.StudentId = newStudent.StudentId;

            _unitOfWork.Commit();
            return item;
        }

        public StudentDto Delete(int id)
        {
            var student= _unitOfWork.Students.GetById(id);
            var studentDto = new StudentDto();

            if (student == null)
            {
                //studentDto.ErrorMessage = "Student not found";
                return studentDto;
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
                //studentDto.ErrorMessage = "Student not Found";
                return studentDto;
            }

            return Mapper.Map<Student, StudentDto>(student);

        }

        public List<StudentDto> GetAll()
        {
            var students= _unitOfWork.Students.GetAll().ToList();
          

            return Mapper.Map<List<Student>, List<StudentDto>>(students);

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
            return Mapper.Map<List<Student>, List<StudentDto>>(students);
        }
    }
}
