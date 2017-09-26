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
    public class BillTagBLL
    {
        IBillTagPrst _DAL = new BillTagPrst();

        public string Create(BillTag v_Value)
        {
           return _DAL.Create(v_Value);
        }

        public BillTag QueryByName(string v_Value)
        {
            return _DAL.QueryByName(v_Value);
        }

        public IQueryable<BillTag> QueryAll()
        {
            return _DAL.QueryAll();
        }

        public string Updte(string v_sBillTagName, BillTag v_NewValue)
        {
            return _DAL.Update(v_sBillTagName, v_NewValue);
        }

        public string Delete(BillTag v_Value)
        {
            return _DAL.Delete(v_Value);
        }
    }
}
