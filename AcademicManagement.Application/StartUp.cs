using AutoMapper;
using System.Web;
using AcademicManagement.Application;

[assembly: PreApplicationStartMethod(type: typeof(StartUp), methodName: "Start")]
namespace AcademicManagement.Application
{
    public static class StartUp
    {
        public static void Start()
        {
            Mapper.Initialize(t => t.AddProfile<MappingProfile>());
        }
    }
}
