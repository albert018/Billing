using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Autofac;
using AutoMapper;

namespace MssqlDAL
{
    class MapperFactory
    {
        private static IContainer _Container;

        static MapperFactory()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.Register<IMapper>(x =>
            {
                var config = new MapperConfiguration(cfg =>
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
                var mapper = config.CreateMapper();
                return mapper;
            }).SingleInstance();

            _Container = builder.Build();
        }

        public static IMapper GetMapper()
        {
            //Sample code
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Source, Dest>();
            //});

            //IMapper mapper = config.CreateMapper();
            //var source = new Source();
            //var dest = mapper.Map<Source, Dest>(source);

            //2017-10-03 Albert 新版的AutoMapper要用Configuration才能CreateMap
            //var config = new MapperConfiguration(cfg =>
            // {
            //     cfg.CreateMap<DailyBillingDTO, DailyBilling>()
            //        .ForMember(dest => dest.Serial
            //            , opt => opt.MapFrom(src => src.Serial));
            // });

            //2017-10-05 改成用Autofac實作 Singleton回傳
            //var config = new MapperConfiguration(cfg =>
            // {
            //     cfg.CreateMap<DailyBilling, DailyBillingDTO>();
            //     cfg.CreateMap<DailyBillingDTO, DailyBilling>();
            //     //cfg.CreateMap<BillTagDTO, BillTag>();
            // });
            //var mapper = config.CreateMapper();
            //return mapper;

            return _Container.Resolve<IMapper>();
        }
    }
}
