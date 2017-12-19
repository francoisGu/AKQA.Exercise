using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using AKQA.Exercise.AppLogic.Configuration;
using AKQA.Exercise.AppLogic.Services;

namespace AKQA.Exercise.AppLogic
{
    public static class SetupDependencyResolver
    {
        public static void RegisterTypes(Container container)
        {
            container.Register(
                    () => container.GetInstance<NumberWordProvider>().BuildConfiguration(),
                    Lifestyle.Singleton);

            container.Register<INumToWords, NumToWords>(Lifestyle.Transient);
        }
    }
}
