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
    public class BillTagBLL:IDisposable
    {
        ILifetimeScope _Scope;
        IBillTagPrst _DAL;

        public BillTagBLL()
        {
            _Scope = Factory.GetLifetimeScope();
            _DAL = _Scope.Resolve<IBillTagPrst>();
        }

        public string Create(BillTagDTO v_Value)
        {
           return _DAL.Create(v_Value);
        }

        public BillTagDTO QueryByName(string v_Value)
        {
            return _DAL.QueryByName(v_Value);
        }

        public IEnumerable<BillTagDTO> QueryAll()
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
