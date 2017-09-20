using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace MssqlDAL
{
    public class BillTypePrst : IBillTypePrst
    {
        private BillingEntities _BillEntities;
        public BillTypePrst()
        {
            _BillEntities = new BillingEntities();
        }

        public string Create(BillType v_Value)
        {
            string sMsg = "";
            try
            {
                _BillEntities.BillType.Add(v_Value);
                _BillEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }

        public string Delete(BillType v_Value)
        {
            string sMsg = "";
            try
            {
                var objTemp = (from x in _BillEntities.BillType
                               where x.BillTypeName == v_Value.BillTypeName
                               select x).First();
                _BillEntities.BillType.Remove(objTemp);
                _BillEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }

        public IQueryable<BillType> QueryAll()
        {
            var result = from x in _BillEntities.BillType
                         select x;
            return result;
        }

        public BillType QueryByName(string v_Value)
        {
            var result = (from x in _BillEntities.BillType
                          where x.BillTypeName == v_Value
                          select x).FirstOrDefault();
            return result;
        }

        public string Update(BillType v_OldValue, BillType v_NewValue)
        {
            string sMsg = "";
            try
            {
                var objTemp = (from x in _BillEntities.BillType
                               where x.BillTypeName == v_OldValue.BillTypeName
                               select x).First();
                objTemp.BillTypeName = v_NewValue.BillTypeName;
                _BillEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }
    }
}
