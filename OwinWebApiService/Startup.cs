using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(OwinWebApiService.Startup))]

namespace OwinWebApiService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            //跨域配置 //need reference from nuget
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            //enabing attribute routing
            config.MapHttpAttributeRoutes();
            // Web API Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );
            config.Services.Replace(typeof(IHttpControllerSelector), new OwinWebApi.Config.WebApiControllerSelector(config));

            //if config the global filter input there need not write the attributes
            //config.Filters.Add(new App.Web.Filters.ExceptionAttribute_DG());

            //new ClassRegisters(); //register ioc menbers

            app.UseWebApi(config);
        }
    }
}
