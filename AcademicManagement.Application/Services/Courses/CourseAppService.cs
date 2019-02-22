using System.Collections.Generic;
using System.Linq;
using AcademicManagement.Application.DTOs.Course;
using AcademicManagement.Domain.Core;
using AcademicManagement.Domain.Entities.Courses;
using AcademicManagement.Persistence;


namespace AcademicManagement.Application.Services.Courses
{
    public class CourseAppService : ICourseAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MyMapping Map;      

        public CourseAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Map = new MyMapping();
        }

        public CourseDto Create(CourseDto item)
        {
            var newCourseDetails = new List<CourseDetail>();

            if (item.CourseDetailDto != null)
            {
                newCourseDetails.AddRange(Map.MapCourseDetailDtoToCourseDetail(item.CourseDetailDto));              
            }

            var newCourse = new Course(item.Name, item.Description)
            {
                CourseDetails = newCourseDetails
            };

            _unitOfWork.Courses.Add(newCourse);

            item.CourseId = newCourse.CourseId;

            _unitOfWork.Commit();
            return item;
        }

        public CourseDto Delete(int id)
        {
            var Course = _unitOfWork.Courses.GetById(id);
            var courseDto = new CourseDto();

            if (Course == null)
            {
                //studentDto.ErrorMessage = "Student not found";
                return courseDto;
            }
            Course.CourseDetails.RemoveAll(item => item.CourseId==id);
            _unitOfWork.Courses.Delete(Course);
            _unitOfWork.Commit();
            return courseDto;
        }

        public List<CourseDto> Find(string query)
        {
            var Courses = _unitOfWork.Courses.Find(query).ToList();
            var cursoDto = Courses.ToList()
             .Select(c => Map.MapCourseToCourseDto(c)).ToList();

            return cursoDto;
        }

        public List<CourseDto> GetAll()
        {
            var Courses = _unitOfWork.Courses.GetAll();

            var cursoDto = Courses.ToList()
              .Select(c=> Map.MapCourseToCourseDto(c) ).ToList();

            return cursoDto;             
        }

        public CourseDto GetById(int id)
        {
            var Course = _unitOfWork.Courses.GetById(id);
            var CourseDto = new CourseDto();
            if (Course == null)
            {
                CourseDto.ErrorMessage = "Student not Found";
                return CourseDto;
            }

            return Map.MapCourseToCourseDto(Course);                
        }

        public CourseDto Update(int id, CourseDto item)
        {
            var CourseOnDB = _unitOfWork.Courses.GetById(id);

            if (CourseOnDB == null)
            {
                item.ErrorMessage = "Course NotFound";
                return item;
            }
            CourseOnDB.UpdateCourse(item.Name, item.Description);
            AddCourseDetail(CourseOnDB, item.CourseDetailDto);
            RemoveCourseDetail(CourseOnDB, item.CourseDetailDto);
            _unitOfWork.Commit();

            return item;
        }

        private void RemoveCourseDetail(Course courseOnDB, List<CourseDetailDto> courseDetail)
        {

            var itemToRemove = courseOnDB.CourseDetails
                .Where(bd => !courseDetail.Any(dto => dto.AsignatureId == bd.AsignatureId)).ToList();

            foreach (var item in itemToRemove)
            {
                _unitOfWork.CourseDetails.Delete(item);              
            }  

        }

        private void AddCourseDetail(Course courseOnDB, List<CourseDetailDto> courseDetailDto)
        {
            foreach (var itemDto in courseDetailDto)
            {
                var newItemBD = courseOnDB.CourseDetails.FirstOrDefault(t => t.AsignatureId == itemDto.AsignatureId);
                if (newItemBD == null)
                {
                    newItemBD = new CourseDetail {AsignatureId=itemDto.AsignatureId };
                    courseOnDB.CourseDetails.Add(newItemBD);
                }
            }
        }
    }
}
