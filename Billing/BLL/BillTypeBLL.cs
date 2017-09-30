using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using MssqlDAL;
using Model;

namespace BLL
{
    public class BillTypeBLL
    {
        IBillTypePrst _DAL = Factory.GetBillTypePrst();

        public string Create(BillType v_Value)
        {
           return _DAL.Create(v_Value);
        }

        public BillType QueryByName(string v_Value)
        {
            return _DAL.QueryByName(v_Value);
        }

        public IQueryable<BillType> QueryAll()
        {
            return _DAL.QueryAll();
        }

        //public string Updte(string v_sBillTagName, BillTag v_NewValue)
        //{
        //    return _DAL.Update(v_sBillTagName, v_NewValue);
        //}

        public string Delete(string v_Value)
        {
            return _DAL.Delete(v_Value);
        }
    }
}
