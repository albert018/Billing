using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
using AutoMapper;

namespace MssqlDAL
{
    public class BillTypePrst : IBillTypePrst
    {
        private BillingEntities _BillEntities;
        private IMapper _Mapper;

        public BillTypePrst()
        {
            _BillEntities = new BillingEntities();
            _Mapper = MapperFactory.GetMapper();
        }

        public string Create(BillTypeDTO v_Value)
        {
            string sMsg = "";
            try
            {
                var BillType = _Mapper.Map<BillType>(v_Value);
                _BillEntities.BillType.Add(BillType);
                _BillEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }

        public string Delete(string v_Value)
        {
            string sMsg = "";
            try
            {
                var objTemp = (from x in _BillEntities.BillType
                               where x.BillTypeName == v_Value
                               select x).First();
                _BillEntities.BillType.Remove(objTemp);
                _BillEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }

        public IEnumerable<BillTypeDTO> QueryAll()
        {
            var QBillType = from x in _BillEntities.BillType
                         select x;
            var RBillTypeDTO = _Mapper.Map<IEnumerable<BillTypeDTO>>(QBillType);
            return RBillTypeDTO;
        }

        public BillTypeDTO QueryByName(string v_Value)
        {
            var QBillType = (from x in _BillEntities.BillType
                          where x.BillTypeName == v_Value
                          select x).FirstOrDefault();
            BillTypeDTO RBillTypeDTO;
            if (QBillType == null)
                RBillTypeDTO = null;
            else
                RBillTypeDTO = _Mapper.Map<BillTypeDTO>(QBillType);
            return RBillTypeDTO;
        }

        //public string Update(BillType v_OldValue, BillType v_NewValue)
        //{
        //    string sMsg = "";
        //    try
        //    {
        //        var objTemp = (from x in _BillEntities.BillType
        //                       where x.BillTypeName == v_OldValue.BillTypeName
        //                       select x).First();
        //        objTemp.BillTypeName = v_NewValue.BillTypeName;
        //        _BillEntities.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        sMsg = ex.Message;
        //    }
        //    return sMsg;
        //}
    }
}
