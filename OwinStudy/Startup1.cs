using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OwinStudy.Startup1))]

namespace OwinStudy
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //这段代码添加一个中间件到OWIN管道，实现为
            //一个接受Microsoft.Owin.IOwinContext实例的功能，
            //服务器接受到一个请求时owin管道调用中间件。
            app.Run(context=>
            {

                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello,owin");//中间件设置响应的内容类型并将内容写入响应的body中。
            });

        }
    }
}
