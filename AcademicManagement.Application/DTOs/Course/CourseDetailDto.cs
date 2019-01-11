using AcademicManagement.Application.DTOs.Core;

namespace AcademicManagement.Application.DTOs.Course
{
    public class CourseDetailDto:BaseDto
    {
        public int CourseDetailId { get; set; }

        public int CourseId { get; set; }

        public int AsignatureId { get; set; }

        public string AsignatureName { get; set; }


    }
}
