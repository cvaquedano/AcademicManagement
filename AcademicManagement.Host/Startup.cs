using AcademicManagement.Application.Services.Students;
using Owin;
using System.Net.Http.Formatting;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace AcademicManagement.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder appbuilder)
        {
            var container = new UnityContainer();
            container.RegisterType<IStudentAppService, StudentAppService>(new HierarchicalLifetimeManager());
           


            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.Routes.MapHttpRoute("default", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            httpConfiguration.DependencyResolver = new UnityResolver(container);
            appbuilder.UseWebApi(httpConfiguration);


            httpConfiguration.Formatters.Clear();
            httpConfiguration.Formatters.Add(new JsonMediaTypeFormatter());





        }

    }
}