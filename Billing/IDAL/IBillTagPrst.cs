using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IBillTagPrst
    {
        string Create(BillTag v_Value);
        BillTag QueryByName(string v_Value);
        IEnumerable<BillTag> QueryAll();
        //string Update(string v_sBillTagName, BillTag v_NewValue);
        string Delete(string v_Value);
    }
}
