using AcademicManagement.Application.DTOs;
using AcademicManagement.Application.Services.Asignatures;
using System.Web.Http;

namespace AcademicManagement.Host.Controllers
{
    public class AsignatureController : ApiController
    {
        private IAsignatureAppService _asignatureAppService;
        public AsignatureController(IAsignatureAppService asignatureAppService)
        {
            _asignatureAppService = asignatureAppService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var resulto = _asignatureAppService.GetAll();

            return Ok(resulto);
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var resulto = _asignatureAppService.GetById(id);

            return Ok(resulto);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var resulto = _asignatureAppService.Delete(id);

            return Ok(resulto);
        }

        [HttpPost]
        public IHttpActionResult Create(AsignatureDto asignatureDto)
        {
            var resulto = _asignatureAppService.Create(asignatureDto);

            return Ok(resulto);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AsignatureDto asignatureDto)
        {
            var resulto = _asignatureAppService.Update(id, asignatureDto);

            return Ok(resulto);
        }
    }
}
