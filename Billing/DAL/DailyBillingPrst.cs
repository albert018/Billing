using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace MssqlDAL
{
    public class DailyBillingPrst : IDailyBillingPrst
    {
        private BillingEntities _entities;

        public DailyBillingPrst()
        {
            _entities = new BillingEntities();
        }

        public string Create(DailyBilling v_Value)
        {
            string sMsg = "";
            try
            {
                _entities.DailyBilling.Add(v_Value);
                _entities.SaveChanges();
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
                var objTemp = (from x in _entities.DailyBilling
                               where x.Serial == v_Value
                               select x).First();
                _entities.DailyBilling.Remove(objTemp);
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }

        public IQueryable<DailyBilling> QueryAll()
        {
            var result = from x in _entities.DailyBilling
                         select x;
            return result;
        }

        public DailyBilling QueryByName(string v_Value)
        {
            var result = (from x in _entities.DailyBilling
                          where x.Serial == v_Value
                          select x).FirstOrDefault();
            return result;
        }

        public string Update(string v_Key, DailyBilling v_NewValue)
        {
            string sMsg = "";
            try
            {
                var objTemp = (from x in _entities.DailyBilling
                               where x.Serial == v_Key
                               select x).First();
                _entities.DailyBilling.Remove(objTemp);
                _entities.DailyBilling.Add(v_NewValue);
                _entities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }
    }
}
