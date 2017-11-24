using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IDailyBillingTagsPrst
    {
        string Create(IEnumerable<DailyBillingTags> v_Value);
        IEnumerable<DailyBillingTags> QueryByName(string v_Value);
        //IEnumerable<DailyBilling> QueryAll();
        //string Update(DailyBilling v_NewValue);
        string Delete(string v_Value);
    }
}
