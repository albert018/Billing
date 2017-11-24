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

        public IEnumerable<BillTag> QueryAll()
        {
            var QBillTag = from x in _BillEntities.BillTag
                         select x;
            return QBillTag;
        }

        public BillTag QueryByName(string v_Value)
        {
            var QBillTag = (from x in _BillEntities.BillTag
                          where x.BillTagName == v_Value
                          select x).FirstOrDefault();

            return QBillTag;
        }
    }
}
