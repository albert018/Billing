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
        string Create(BillTagDTO v_Value);
        BillTagDTO QueryByName(string v_Value);
        IEnumerable<BillTagDTO> QueryAll();
        //string Update(string v_sBillTagName, BillTag v_NewValue);
        string Delete(string v_Value);
    }
}
