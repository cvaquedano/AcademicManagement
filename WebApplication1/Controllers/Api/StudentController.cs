using AcademicManagement.Application.DTOs;
using AcademicManagement.Application.Services.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers.Api
{
    public class StudentController : ApiController
    {
        private IStudentAppService _studentAppService;
        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;// new StudentAppService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var resulto = _studentAppService.GetStudents();

            return Ok(resulto);
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var resulto = _studentAppService.GetStudentById(id);

            return Ok(resulto);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var resulto = _studentAppService.DeleteStudent(id);

            return Ok(resulto);
        }

        [HttpPost]
        public IHttpActionResult Create(StudentDto studentDto)
        {
            var resulto = _studentAppService.CreateStudent(studentDto);

            return Ok(resulto);
        }

        [HttpPost]
        public IHttpActionResult Update(int id, StudentDto studentDto)
        {
            var resulto = _studentAppService.UpdateStudent(id,studentDto);

            return Ok(resulto);
        }

    }
}
