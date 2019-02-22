using AcademicManagement.Domain.Entities.Courses;
using System.Collections.Generic;
using System.Linq;

namespace AcademicManagement.Domain.Entities.AcademicPeriods
{
    public class AcademicPeriodDetail
    {
        public int AcademicPeriodDetailId { get; set; }
        public int AcademicPeriodId { get; set; }
        public string Section { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public AcademicPeriod AcademicPeriod { get; set; }

        public List<AcademicPeriodCourseAsignature> AcademicPeriodCourseAsignature { get;  private set; }


        public AcademicPeriodDetail(string section, Course course)
        {
            Section = section;
            CourseId = course.CourseId;
            CourseName = course.Name;
            AcademicPeriodCourseAsignature = new List<AcademicPeriodCourseAsignature>();
            AddCourseAsignature(course.CourseDetails);
        }

        //public void AddCourseAsignature(AcademicPeriodCourseAsignature item)
        //{
        //    AcademicPeriodCourseAsignature.Add(item);
        //}

        //public void AddCourseAsignature(List<AcademicPeriodCourseAsignature> items)
        //{
        //    AcademicPeriodCourseAsignature.AddRange(items);
        //}


        //public void AddCourseAsignature(CourseDetail item)
        //{
        //    AcademicPeriodCourseAsignature newItem = new AcademicPeriodCourseAsignature(item.AsignatureId,item.Asignature.Name);
        //    AcademicPeriodCourseAsignature.Add(newItem);
        //}

        public void AddCourseAsignature(List<CourseDetail> items)
        {          
          
            AcademicPeriodCourseAsignature.AddRange(items.Select(t => new AcademicPeriodCourseAsignature(t.AsignatureId, t.Asignature.Name)));
        }



    }
}
