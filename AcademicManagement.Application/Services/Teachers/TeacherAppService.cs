using System;
using System.Collections.Generic;
using System.Linq;
using AcademicManagement.Application.DTOs;
using AcademicManagement.Domain.Core;
using AcademicManagement.Domain.Entities;
using AcademicManagement.Persistence;
using AutoMapper;

namespace AcademicManagement.Application.Services.Teachers
{
    public class TeacherAppService : ITeacherAppService
    {
        private readonly IUnitOfWork _unitOfWork;


        public TeacherAppService()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }


        public TeacherDto Create(TeacherDto item)
        {
            var newTeacher = new Teacher
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                BirthDate = item.BirthDate,
                Gender = item.Gender,
              
            };
            _unitOfWork.Teachers.Add(newTeacher);

            item.TeacherId = newTeacher.TeacherId;

            _unitOfWork.Commit();
            return item;
        }

        public TeacherDto Delete(int id)
        {
            var teacher = _unitOfWork.Teachers.GetById(id);
            var teacherDto = new TeacherDto();

            if (teacher == null)
            {
                //studentDto.ErrorMessage = "Student not found";
                return teacherDto;
            }
            _unitOfWork.Teachers.Delete(teacher);
            _unitOfWork.Commit();
            return teacherDto;
        }

        public List<TeacherDto> GetAll()
        {
            var teachers = _unitOfWork.Teachers.GetAll().ToList();


            return Mapper.Map<List<Teacher>, List<TeacherDto>>(teachers);
        }

        public TeacherDto GetById(int id)
        {
            var teacher = _unitOfWork.Teachers.GetById(id);
            var teacherDto = new TeacherDto();
            if (teacher == null)
            {
                //studentDto.ErrorMessage = "Student not Found";
                return teacherDto;
            }

            return Mapper.Map<Teacher, TeacherDto>(teacher);
        }

        public TeacherDto Update(int id, TeacherDto item)
        {
            var teacherOnDB = _unitOfWork.Teachers.GetById(id);

            if (teacherOnDB == null)
            {
                //item.ErrorMessage = "StudentNotFound";
                return item;
            }
            teacherOnDB.FirstName = item.FirstName;
            teacherOnDB.LastName = item.LastName;
            teacherOnDB.BirthDate = item.BirthDate;
            teacherOnDB.Gender = item.Gender;
         

            _unitOfWork.Commit();

            return item;
        }
    }
}
