using AcademicManagement.Application.DTOs;
using AcademicManagement.Application.Services.Students;
using System.Threading;
using System.Web.Http;

namespace AcademicManagement.Host.Controllers
{
    public class StudentController : ApiController
    {
        private IStudentAppService _studentAppService;
        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
          
            var resulto = _studentAppService.GetAll();

            return Ok(resulto);
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var resulto = _studentAppService.GetById(id);

            return Ok(resulto);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var resulto = _studentAppService.Delete(id);

            return Ok(resulto);
        }

        [HttpPost]
        public IHttpActionResult Create(StudentDto studentDto)
        {
            var resulto = _studentAppService.Create(studentDto);

            return Ok(resulto);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, StudentDto studentDto)
        {
            var resulto = _studentAppService.Update(id, studentDto);

            return Ok(resulto);
        }
    }
}
