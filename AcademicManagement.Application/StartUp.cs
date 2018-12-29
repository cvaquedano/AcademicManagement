using AutoMapper;
using System.Web;
using AcademicManagement.Application;

[assembly: PreApplicationStartMethod(typeof(StartUp), "Start")]
namespace AcademicManagement.Application
{
    public static class StartUp
    {
        static void Start()
        {
            Mapper.Initialize(t => t.AddProfile<MappingProfile>());
        }
    }
}
