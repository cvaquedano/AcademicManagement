using AcademicManagement.Application.DTOs;
using AcademicManagement.Domain.Entities;
using AcademicManagement.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AcademicManagement.Application.Services.Students
{
    public class StudentAppService: IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentAppService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        private void Commit()
        {
            _studentRepository.UnitOfWork.Commit();
        }

        public StudentDto CreateStudent(StudentDto student)
        {
            var newStudent = new Student
            {
                FirstName=student.FirstName,
                LastName=student.LastName,
                BirthDate=student.BirthDay,
                Gender=student.Genre,
                IsRightHanded=student.IsRightHanded
            };
            _studentRepository.Add(newStudent);

            student.StudentId = newStudent.StudentId;

            Commit();
            return student;
        }

        public StudentDto DeleteStudent(int id)
        {
            var student=_studentRepository.GetById(id);
            var studentDto = new StudentDto();

            if (student == null)
            {
                studentDto.ErrorMessage = "Student not found";
                return studentDto;
            }
            _studentRepository.Delete(student);
            Commit();
            return studentDto;
        }

        public StudentDto GetStudentById(int id)
        {
            var student = _studentRepository.GetById(id);
            var studentDto = new StudentDto();
            if (student == null)
            {
                studentDto.ErrorMessage = "Student not Found";
                return studentDto;
            }

            return Mapper.Map<Student, StudentDto>(student);

        }

        public List<StudentDto> GetStudents()
        {
            throw new NotImplementedException();
        }

        public StudentDto UpdateStudent(StudentDto student)
        {
            throw new NotImplementedException();
        }
    }
}
