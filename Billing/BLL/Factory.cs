using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IDAL;
using MssqlDAL;
using AutoMapper;
using Model;

namespace BLL
{
    internal static class Factory
    {
        private static IContainer _Container;

        static Factory()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //interface
            builder.RegisterType<BillTagPrst>().As<IBillTagPrst>();
            builder.RegisterType<BillTypePrst>().As<IBillTypePrst>();
            builder.RegisterType<DailyBillingPrst>().As<IDailyBillingPrst>();
            builder.RegisterType<DailyBillingTagsPrst>().As<IDailyBillingTagsPrst>();

            //AutoMapper
            builder.Register<IMapper>(x =>
            {
                var Mapper = new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<DailyBilling, DailyBillingDTO>();
                     cfg.CreateMap<DailyBillingDTO, DailyBilling>();
                     cfg.CreateMap<DailyBillingTagsDTO, DailyBillingTags>();
                     cfg.CreateMap<DailyBillingTags, DailyBillingTagsDTO>();
                     cfg.CreateMap<BillTag, BillTagDTO>();
                     cfg.CreateMap<BillTagDTO, BillTag>();
                     cfg.CreateMap<BillType, BillTypeDTO>();
                     cfg.CreateMap<BillTypeDTO, BillType>();
                 });
                return Mapper.CreateMapper();
            }).SingleInstance();

            _Container = builder.Build();
        }

        public static ILifetimeScope GetLifetimeScope()
        {
            return _Container.BeginLifetimeScope();
        }

        public static IMapper GetMapper()
        {
            return _Container.Resolve<IMapper>();
        }
    }
}
