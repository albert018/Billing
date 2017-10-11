using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IDAL;
using MssqlDAL;

namespace BLL
{
    internal static class Factory
    {
        private static IContainer _Container;

        static Factory()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<BillTagPrst>().As<IBillTagPrst>();
            builder.RegisterType<BillTypePrst>().As<IBillTypePrst>();
            builder.RegisterType<DailyBillingPrst>().As<IDailyBillingPrst>();

            _Container = builder.Build();
        }

        public static ILifetimeScope GetLifetimeScope()
        {
            return _Container.BeginLifetimeScope();
        }
    }
}
