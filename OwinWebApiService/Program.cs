using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinWebApiService
{
    class Program
    {
        //        OWIN
        //Microsoft.Owin.Hosting
        //Microsoft.Owin.Host.HttpListener
        //Microsoct.AspNet.WebApi.Owin
        //这里需要手动从WebApi项目里面找到System.Web.Web, System.Net.Http等Web类库进行引用。
        //OWIN.WebApi.Srv层的引用情况（我这里有跨域配置，不需要的请忽略）
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:3999/";

            using (WebApp.Start<Startup>(url: baseAddress)) {
                Console.WriteLine("开启");
                Console.Read();

            }
        }
    }
}
