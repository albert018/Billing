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

        public string Delete(string v_Value)
        {
            string sMsg = "";
            try
            {
                var objTemp = (from x in _BillEntities.BillType
                               where x.BillTypeName == v_Value
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

        public IEnumerable<BillType> QueryAll()
        {
            var QBillType = from x in _BillEntities.BillType
                         select x;
            return QBillType;
        }

        public BillType QueryByName(string v_Value)
        {
            var QBillType = (from x in _BillEntities.BillType
                          where x.BillTypeName == v_Value
                          select x).FirstOrDefault();
            return QBillType;
        }

        //public string Update(BillType v_OldValue, BillType v_NewValue)
        //{
        //    string sMsg = "";
        //    try
        //    {
        //        var objTemp = (from x in _BillEntities.BillType
        //                       where x.BillTypeName == v_OldValue.BillTypeName
        //                       select x).First();
        //        objTemp.BillTypeName = v_NewValue.BillTypeName;
        //        _BillEntities.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        sMsg = ex.Message;
        //    }
        //    return sMsg;
        //}
    }
}
