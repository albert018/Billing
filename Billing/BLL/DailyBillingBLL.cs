using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Model;
using IDAL;
using MssqlDAL;
using AutoMapper;

namespace BLL
{
    public class DailyBillingBLL:IDisposable
    {
        ILifetimeScope _Scope;
        IMapper _Mapper;
        IDailyBillingPrst _DailyBilling;
        IDailyBillingTagsPrst _DailyBillingTags;

        public DailyBillingBLL()
        {
            _Scope = Factory.GetLifetimeScope();
            _Mapper = Factory.GetMapper();
            _DailyBilling = _Scope.Resolve<IDailyBillingPrst>();
            _DailyBillingTags = _Scope.Resolve<IDailyBillingTagsPrst>();
        }

        public string Create(DailyBillingDTO v_Value)
        {
            string sMsg = "";
            var DailyBilling = _Mapper.Map<DailyBilling>(v_Value);
            var DailyBillingTags = _Mapper.Map<IEnumerable<DailyBillingTags>>(v_Value.BillTags);
            sMsg = _DailyBilling.Create(DailyBilling);
            sMsg += _DailyBillingTags.Create(DailyBillingTags);
            return sMsg;
        }

        public DailyBillingDTO QueryByName(string v_Value)
        {
            var R = _Mapper.Map<DailyBillingDTO>(_DailyBilling.QueryByName(v_Value));
            R.BillTags = _Mapper.Map<IEnumerable<DailyBillingTagsDTO>>(_DailyBillingTags.QueryByName(v_Value));
            return R;
        }

        public IEnumerable<DailyBillingDTO> QueryAll()
        {
            return _Mapper.Map<IEnumerable<DailyBillingDTO>>(_DailyBilling.QueryAll());
        }

        public string Update(DailyBillingDTO v_Value)
        {
            string sMsg = "";
            var DailyBilling = _Mapper.Map<DailyBilling>(v_Value);
            var DailyBillingTags = _Mapper.Map<IEnumerable<DailyBillingTags>>(v_Value.BillTags);
            sMsg = _DailyBilling.Update(DailyBilling);
            sMsg += _DailyBillingTags.Delete(DailyBillingTags.First().Serial);
            sMsg += _DailyBillingTags.Create(DailyBillingTags);
            return sMsg;
        }

        public string Delete(string v_Value)
        {
            string sMsg = "";
            sMsg = _DailyBilling.Delete(v_Value);
            sMsg += _DailyBillingTags.Delete(v_Value);
            return sMsg;
        }

        public void Dispose()
        {
            _Scope.Dispose();
        }
    }
}
