using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IDailyBillingPrst
    {
        string Create(DailyBillingDTO v_Value);
        DailyBillingDTO QueryByName(string v_Value);
        IEnumerable<DailyBillingDTO> QueryAll();
        string Update(string v_Key, DailyBillingDTO v_NewValue);
        string Delete(string v_Value);
    }
}
