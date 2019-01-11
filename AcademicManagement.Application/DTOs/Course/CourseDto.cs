using AcademicManagement.Application.DTOs.Core;
using System.Collections.Generic;

namespace AcademicManagement.Application.DTOs.Course
{
    public class CourseDto:BaseDto
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<CourseDetailDto> CourseDetailDto { get; set; }


        public CourseDto()
        {
            CourseDetailDto = new List<CourseDetailDto>();
        }
    }
}
