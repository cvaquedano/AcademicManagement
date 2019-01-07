using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AcademicManagement.Domain.Entities.Courses
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<CourseDetail> CourseDetails { get; set; }

        public Course()
        {
            CourseDetails = new Collection<CourseDetail>();
        }
    }
}
