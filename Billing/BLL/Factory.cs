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

        public static IBillTagPrst GetBillTagPrst()
        {
            using (var scope = _Container.BeginLifetimeScope())
            {
                //return _Container.Resolve<IBillTagPrst>();
                return scope.Resolve<IBillTagPrst>();
            }
        }

        public static IBillTypePrst GetBillTypePrst()
        {
            return _Container.Resolve<IBillTypePrst>();
        }

        public static IDailyBillingPrst GetDailyBillingPrst()
        {
            return _Container.Resolve<IDailyBillingPrst>();
        }
    }
}
