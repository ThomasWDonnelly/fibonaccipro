using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Fibonacci.Lib.Calculators;

namespace Fibonacci.Web
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            //autofac 
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //types
            builder.RegisterType<ArrayCalculator>().As<IFibonacciCalculator>();

            //go
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}