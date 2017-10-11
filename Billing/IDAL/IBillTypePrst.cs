using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IBillTypePrst
    {
        string Create(BillTypeDTO v_Value);
        BillTypeDTO QueryByName(string v_Value);
        IEnumerable<BillTypeDTO> QueryAll();
        //string Update(BillType v_OldValue, BillType v_NewValue);
        string Delete(string v_Value);
    }
}
