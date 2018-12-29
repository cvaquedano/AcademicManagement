using AcademicManagement.Application.DTOs;
using AcademicManagement.Domain.Entities;
using AutoMapper;

namespace AcademicManagement.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg => {
               
                cfg.CreateMap<Student, StudentDto>();
            });


            config.CreateMapper();


        }

    }
}
