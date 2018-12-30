using AcademicManagement.Application.Services.Students;
using System.Net.Http.Formatting;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IStudentAppService, StudentAppService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);



            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

        }
    }
}
