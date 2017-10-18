using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Hosting;
 using System.Web.Http.Dispatcher;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(OWinConsoleApp1.Startup1))]

namespace OWinConsoleApp1
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //app.Run(context =>
            //{

            //    context.Response.ContentType = "text/plain";
            //    return context.Response.WriteAsync("Hello,owin");//中间件设置响应的内容类型并将内容写入响应的body中。
            //});
            //添加错误页中间节到管道
            //app.UseErrorPage();
            //app.Run(context =>
            //{
            //    if (context.Request.Path.Value == "/fail")
            //    {
            //        throw new Exception("错误");
            //    }
            //    context.Response.ContentType = "text/plain";
            //    return context.Response.WriteAsync("Hello, world.");
            //});
            //

            //Configure WebApi FOR self-host

            HttpConfiguration configuration = new HttpConfiguration();
            configuration.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            //enabing attribute routing
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name:"DefaultApi",
                routeTemplate:"api/{controller}/{id}",
                defaults:new { id=RouteParameter.Optional}
                
                );
           // configuration.Services.Replace(typeof(IHttpControllerSelector), new WebApiOwin.WebApiApplication.Register(configuration));
            app.UseWebApi(configuration);
        }
    }
}
