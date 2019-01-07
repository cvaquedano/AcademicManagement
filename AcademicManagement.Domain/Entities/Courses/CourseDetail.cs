namespace AcademicManagement.Domain.Entities.Courses
{
    public class CourseDetail
    {
        public int CourseDetailId { get; set; }

        public int CourseId { get; set; }

        public int AsignatureId { get; set; }

        public Course Course { get; set; }
        public Asignature Asignature { get; set; }
    }
}
