﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IBillTypePrst
    {
        string Create(BillType v_Value);
        BillType QueryByName(string v_Value);
        IEnumerable<BillType> QueryAll();
        //string Update(BillType v_OldValue, BillType v_NewValue);
        string Delete(string v_Value);
    }
}
