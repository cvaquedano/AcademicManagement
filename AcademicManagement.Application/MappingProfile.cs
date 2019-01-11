using AcademicManagement.Application.DTOs;
using AcademicManagement.Application.DTOs.Course;
using AcademicManagement.Domain.Entities;
using AcademicManagement.Domain.Entities.Courses;
using AutoMapper;

namespace AcademicManagement.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           

            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Student, StudentDto>() ;//.ForMember(s=>s.ErrorMessage,q=>q.Ignore());
                cfg.CreateMap<Teacher, TeacherDto>();
                cfg.CreateMap<Asignature, AsignatureDto>();
              

                // cfg.CreateMap<CourseDetail, CourseDetailDto>().ForMember(a=>a.AsignatureName, q=>q.MapFrom(s=>s.Asignature.Name));





                cfg.CreateMap<CourseDetailDto, CourseDetail>() ;
                cfg.CreateMap<CourseDto, Course>().ForMember(d => d.CourseDetails, q => q.MapFrom(a => a.CourseDetailDto));

               
            });

            config.CreateMapper();


        }

    }
}
