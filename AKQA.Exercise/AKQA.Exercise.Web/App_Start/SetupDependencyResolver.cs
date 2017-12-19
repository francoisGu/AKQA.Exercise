using System;
using System.ServiceModel;
using AKQA.Exercise.AppLogic;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace AKQA.Exercise.Web.App_Start
{
    public static class SetupDependencyResolver
    {
        public static readonly Container Container;

        static SetupDependencyResolver()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            AppLogic.SetupDependencyResolver.RegisterTypes(container);
            Container = container;
        }
    }
}