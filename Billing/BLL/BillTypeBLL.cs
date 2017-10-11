using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IDAL;
using MssqlDAL;
using Model;

namespace BLL
{
    public class BillTypeBLL:IDisposable
    {
        ILifetimeScope _Scope;
        IBillTypePrst _DAL;

        public BillTypeBLL()
        {
            _Scope = Factory.GetLifetimeScope();
            _DAL = _Scope.Resolve<IBillTypePrst>();
        }

        public string Create(BillTypeDTO v_Value)
        {
           return _DAL.Create(v_Value);
        }

        public BillTypeDTO QueryByName(string v_Value)
        {
            return _DAL.QueryByName(v_Value);
        }

        public IEnumerable<BillTypeDTO> QueryAll()
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

        public void Dispose()
        {
            _Scope.Dispose();
        }
    }
}
