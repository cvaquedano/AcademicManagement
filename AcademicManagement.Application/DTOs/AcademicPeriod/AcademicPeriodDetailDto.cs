using AcademicManagement.Application.DTOs.Core;

namespace AcademicManagement.Application.DTOs.AcademicPeriod
{
    public  class AcademicPeriodDetailDto:BaseDto
    {
        public int AcademicPeriodDetailId { get; set; }
        public int AcademicPeriodId { get; set; }
        public string Section { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public AcademicPeriodDetailDto(string section, int courseId, string courseName)
        {
            Section = section;
            CourseId = courseId;
            CourseName = courseName;
        }
    }
}
