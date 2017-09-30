using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using MssqlDAL;

namespace BLL
{
    public class DailyBillingBLL
    {
        IDailyBillingPrst _DAL = Factory.GetDailyBillingPrst();

        public string Create(DailyBilling v_Value)
        {
            v_Value.Serial = Guid.NewGuid().ToString();
            return _DAL.Create(v_Value);
        }

        public DailyBilling QueryByName(string v_Value)
        {
            return _DAL.QueryByName(v_Value);
        }

        public IQueryable<DailyBilling> QueryAll()
        {
            return _DAL.QueryAll();
        }

        public string Updte(string v_sKey, DailyBilling v_NewValue)
        {
            return _DAL.Update(v_sKey, v_NewValue);
        }

        public string Delete(string v_Value)
        {
            return _DAL.Delete(v_Value);
        }
    }
}
