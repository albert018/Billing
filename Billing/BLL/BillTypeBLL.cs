using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IDAL;
using Model;
using AutoMapper;

namespace BLL
{
    public class BillTypeBLL:IDisposable
    {
        ILifetimeScope _Scope;
        IBillTypePrst _DAL;
        IMapper _Mapper;

        public BillTypeBLL()
        {
            _Scope = Factory.GetLifetimeScope();
            _DAL = _Scope.Resolve<IBillTypePrst>();
            _Mapper = Factory.GetMapper();
        }

        public string Create(BillTypeDTO v_Value)
        {
           return _DAL.Create(_Mapper.Map<BillType>(v_Value));
        }

        public BillTypeDTO QueryByName(string v_Value)
        {
            var R = _DAL.QueryByName(v_Value);
            return R == null ? null : _Mapper.Map<BillTypeDTO>(R);
        }

        public IEnumerable<BillTypeDTO> QueryAll()
        {
            return _Mapper.Map<IEnumerable<BillTypeDTO>>(_DAL.QueryAll());
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
