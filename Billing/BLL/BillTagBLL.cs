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
    public class BillTagBLL:IDisposable
    {
        ILifetimeScope _Scope;
        IMapper _Mapper;
        IBillTagPrst _DAL;

        public BillTagBLL()
        {
            _Scope = Factory.GetLifetimeScope();
            _Mapper = Factory.GetMapper();
            _DAL = _Scope.Resolve<IBillTagPrst>();
        }

        public string Create(BillTagDTO v_Value)
        {
            var BillTag = _Mapper.Map<BillTag>(v_Value);
           return _DAL.Create(BillTag);
        }

        public BillTagDTO QueryByName(string v_Value)
        {
            var Q = _DAL.QueryByName(v_Value);
            return Q == null ? null : _Mapper.Map<BillTagDTO>(Q);
        }

        public IEnumerable<BillTagDTO> QueryAll()
        {
            return _Mapper.Map<IEnumerable<BillTagDTO>>(_DAL.QueryAll());
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
