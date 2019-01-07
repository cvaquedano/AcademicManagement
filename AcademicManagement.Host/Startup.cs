using AcademicManagement.Application.Services.Students;
using AcademicManagement.Application.Services.Teachers;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace AcademicManagement.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder appbuilder)
        {
           
            var container = new UnityContainer();
            RegisterTypes(container);

           ;

            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.Routes.MapHttpRoute("default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            httpConfiguration.EnableCors(corsAttr);


            httpConfiguration.DependencyResolver = new UnityResolver(container);
            appbuilder.UseWebApi(httpConfiguration);

         

            httpConfiguration.Formatters.Clear();
            httpConfiguration.Formatters.Add(new JsonMediaTypeFormatter());

        }


        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterTypes(
            AllClasses.FromLoadedAssemblies(),
            WithMappings.FromMatchingInterface,
            WithName.Default);
        }
    }
}