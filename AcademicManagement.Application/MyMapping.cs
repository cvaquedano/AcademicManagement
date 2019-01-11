using AcademicManagement.Application.DTOs.Course;
using AcademicManagement.Domain.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Application
{
    public class MyMapping
    {
        public CourseDto MapCourseToCourseDto(Course source)
        {
            var course = new CourseDto()
            {
                CourseId = source.CourseId,
                Name = source.Name,
                Description = source.Description,
                CourseDetailDto = MapCourseDetailToCourseDetailDto(source.CourseDetails)
                
            };

            return course;

        }

        public List<CourseDetailDto> MapCourseDetailToCourseDetailDto(List<CourseDetail> courseDetail)
        {
            var listCourseDetail = new List<CourseDetailDto>();
            if (courseDetail != null && courseDetail.Any())
            {
                foreach (var item in courseDetail)
                {
                    listCourseDetail.Add(new CourseDetailDto
                    {
                        CourseId=item.CourseId,
                        CourseDetailId=item.CourseDetailId,
                        AsignatureId = item.AsignatureId,
                        AsignatureName = item.Asignature.Name

                    });
                }
            }
            return listCourseDetail;
        }

        public Course MapCourseDtoToCourse(CourseDto sourceDto)
        {
            var course = new Course()
            {
                CourseId = sourceDto.CourseId,
                Name = sourceDto.Name,
                Description = sourceDto.Description,
                CourseDetails = MapCourseDetailDtoToCourseDetail(sourceDto.CourseDetailDto)

            };

            return course;

        }

        public List<CourseDetail> MapCourseDetailDtoToCourseDetail(List<CourseDetailDto> courseDetailDto)
        {
            var listCourseDetail = new List<CourseDetail>();
            if (courseDetailDto != null && courseDetailDto.Any())
            {
                foreach (var item in courseDetailDto)
                {
                    listCourseDetail.Add(new CourseDetail
                    {
                        CourseId = item.CourseId,                        
                        AsignatureId = item.AsignatureId,                      

                    });
                }
            }
            return listCourseDetail;
        }
    }
}
