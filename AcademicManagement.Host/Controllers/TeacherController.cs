using AcademicManagement.Application.DTOs;
using AcademicManagement.Application.Services.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AcademicManagement.Host.Controllers
{
    public class TeacherController : ApiController
    {
        private ITeacherAppService _teacherAppService;
        public TeacherController(ITeacherAppService teacherAppService)
        {
            _teacherAppService = teacherAppService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var resulto = _teacherAppService.GetAll();

            return Ok(resulto);
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var resulto = _teacherAppService.GetById(id);

            return Ok(resulto);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var resulto = _teacherAppService.Delete(id);

            return Ok(resulto);
        }

        [HttpPost]
        public IHttpActionResult Create(TeacherDto teacherDto)
        {
            var resulto = _teacherAppService.Create(teacherDto);

            return Ok(resulto);
        }

        [HttpPost]
        public IHttpActionResult Update(int id, TeacherDto teacherDto)
        {
            var resulto = _teacherAppService.Update(id, teacherDto);

            return Ok(resulto);
        }

    }
}
