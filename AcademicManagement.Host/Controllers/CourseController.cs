using AcademicManagement.Application.DTOs.Course;
using AcademicManagement.Application.Services.Courses;
using System.Web.Http;

namespace AcademicManagement.Host.Controllers
{
    public class CourseController : ApiController
    {
        private ICourseAppService _courseAppService;
        public CourseController(ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var resulto = _courseAppService.GetAll();

            var courseDto = new CourseDto
            {
                Name = "PRueba3",
                Description = "Prueba tres Editada",
                CourseDetailDto = new System.Collections.Generic.List<CourseDetailDto>
                {
                    new CourseDetailDto{AsignatureId=2},
                     new CourseDetailDto{AsignatureId=4}
                }
                
            };


            var resulto1 = _courseAppService.Update(3, courseDto);

            return Ok(resulto);
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var resulto = _courseAppService.GetById(id);

            return Ok(resulto);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var resulto = _courseAppService.Delete(id);

            return Ok(resulto);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseDto courseDto)
        {
            var resulto = _courseAppService.Create(courseDto);

            return Ok(resulto);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CourseDto courseDto)
        {
            var resulto = _courseAppService.Update(id, courseDto);

            return Ok(resulto);
        }
    }
}
