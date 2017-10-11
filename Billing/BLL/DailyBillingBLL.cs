using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Model;
using IDAL;
using MssqlDAL;

namespace BLL
{
    public class DailyBillingBLL:IDisposable
    {
        ILifetimeScope _Scope;
        IDailyBillingPrst _DAL;

        public DailyBillingBLL()
        {
            _Scope = Factory.GetLifetimeScope();
            _DAL = _Scope.Resolve<IDailyBillingPrst>();
        }

        public string Create(DailyBillingDTO v_Value)
        {
            return _DAL.Create(v_Value);
        }

        public DailyBillingDTO QueryByName(string v_Value)
        {
            return _DAL.QueryByName(v_Value);
        }

        public IEnumerable<DailyBillingDTO> QueryAll()
        {
            return _DAL.QueryAll();
        }

        public string Updte(string v_sKey, DailyBillingDTO v_NewValue)
        {
            return _DAL.Update(v_sKey, v_NewValue);
        }

        public string Delete(string v_Value)
        {
            return _DAL.Delete(v_Value);
        }

        public void Dispose()
        {
            _Scope.Dispose();
        }
    }
}
