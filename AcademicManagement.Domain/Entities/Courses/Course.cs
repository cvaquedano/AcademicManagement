using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicManagement.Domain.Entities.Courses
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<CourseDetail> CourseDetails { get; set; }

        public Course()
        {
            CourseDetails = new List<CourseDetail>();
        }
        public Course( string name,string description)
        {
           
            Name = name;
            Description = description;
            CourseDetails = new List<CourseDetail>();

        }

        public void UpdateCourse(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AddDetail(CourseDetail detail)
        {
            CourseDetails.Add(detail);
        }

        public void RemoveDetail(CourseDetail detail)
        {
            CourseDetails.Remove(detail);
        }
       
        public void RemoveDetail(int detailId)
        {
            var courseDetail= CourseDetails.FirstOrDefault(d => d.CourseDetailId == detailId);
            CourseDetails.Remove(courseDetail);
        }

        public List<CourseDetail> ObtenerCursoDetalle()
        {
            if (CourseDetails != null && CourseDetails.Any())
            {
               
                return CourseDetails.ToList();
            }
            return new List<CourseDetail>();
        }
    }
}
