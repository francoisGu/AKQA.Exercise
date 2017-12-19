using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using AKQA.Exercise.Web.App_Start;

namespace AKQA.Exercise.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SetupDependencyResolver.Container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(SetupDependencyResolver.Container));
            ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
        }
    }
}
