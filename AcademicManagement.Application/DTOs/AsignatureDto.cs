using AcademicManagement.Application.DTOs.Core;

namespace AcademicManagement.Application.DTOs
{
    public class AsignatureDto:BaseDto
    {
        public int AsignatureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
