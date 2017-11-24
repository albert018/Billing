using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace MssqlDAL
{
    public class DailyBillingTagsPrst : IDailyBillingTagsPrst
    {
        private BillingEntities _BillEntities;

        public DailyBillingTagsPrst()
        {
            _BillEntities = new BillingEntities();
        }

        public string Create(IEnumerable<DailyBillingTags> v_Value)
        {
            string sMsg = "";
            try
            {
                _BillEntities.DailyBillingTags.AddRange(v_Value);
                _BillEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }

        public string Delete(string v_Value)
        {
            string sMsg = "";
            try
            {
                var Q = from x in _BillEntities.DailyBillingTags
                               where x.Serial == v_Value
                               select x;
                _BillEntities.DailyBillingTags.RemoveRange(Q);
                _BillEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }

        public IEnumerable<DailyBillingTags> QueryByName(string v_Value)
        {
            var Q = from x in _BillEntities.DailyBillingTags
                    where x.Serial == v_Value
                    select x;

            return Q;
        }
    }
}
