using Autofac;
using Autofac.Configuration;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Mvc;
using AutoFac.Service;
using AutoFacStudy.AOP;
using AutoFacStudy.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AutoFacStudy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //using Autofac;
            //using Autofac.Configuration;
            //using Autofac.Integration.Mvc;
            //using Microsoft.Extensions.Configuration;
            //using Microsoft.Extensions.Configuration.Json;
            //导包

            ContainerBuilder builder = new Autofac.ContainerBuilder();//容器创建
            IConfigurationBuilder config = new ConfigurationBuilder();//配置文件创建
            IConfigurationSource autofacJsonConfigSource = new JsonConfigurationSource()
            {
                Path = "/config/autofac.json",
                Optional = false,//boolean,默认就是false,可不写
                ReloadOnChange = false,//同上
            };
            config.Add(autofacJsonConfigSource);//加入配置文件
            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());//创建module
            //这是实现了AOP拦截
            //builder.RegisterType<StudyService>().As<IStudy>().InterceptedBy(typeof(CallLogger)).EnableInterfaceInterceptors();
            //builder.Register(c => new CallLogger());
            builder.RegisterModule(module);//注册组件通过json文件
            builder.RegisterControllers(typeof(MvcApplication).Assembly);//注册MVC中的Contrillers
           
            var container = builder.Build();//创建容器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//创建




        }
    }
}
