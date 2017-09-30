using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace MssqlDAL
{
    public class BillTagPrst : IBillTagPrst
    {
        private BillingEntities _BillEntities;
        public BillTagPrst()
        {
            _BillEntities = new BillingEntities();
        }

        public string Create(BillTag v_Value)
        {
            string sMsg = "";
            try
            {
                _BillEntities.BillTag.Add(v_Value);
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
                var objTemp = (from x in _BillEntities.BillTag
                               where x.BillTagName == v_Value
                               select x).First();
                _BillEntities.BillTag.Remove(objTemp);
                _BillEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }

        public IQueryable<BillTag> QueryAll()
        {
            var result = from x in _BillEntities.BillTag
                         select x;
            return result;
        }

        public BillTag QueryByName(string v_Value)
        {
            var result = (from x in _BillEntities.BillTag
                          where x.BillTagName == v_Value
                          select x).FirstOrDefault();
            return result;
        }

        //public string Update(string v_sBillTagName, BillTag v_NewValue)
        //{
        //    string sMsg = "";
        //    try
        //    {
        //        var objTemp = (from x in _BillEntities.BillTag
        //                       where x.BillTagName == v_sBillTagName
        //                       select x).First();
        //        objTemp.BillTagName = v_NewValue.BillTagName;
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
