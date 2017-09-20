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
        public string Create(BillTag v_Value)
        {
            string sMsg = "";
            var DAL = new BillTagPrst();
            sMsg = DAL.Create(v_Value);
            return sMsg;
        }
    }
}
