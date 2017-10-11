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
    public class BillTagPrst : IBillTagPrst
    {
        private BillingEntities _BillEntities;
        private IMapper _Mapper;

        public BillTagPrst()
        {
            _BillEntities = new BillingEntities();
            _Mapper = MapperFactory.GetMapper();
        }

        public string Create(BillTagDTO v_Value)
        {
            string sMsg = "";
            try
            {
                var BillTag = _Mapper.Map<BillTag>(v_Value);
                _BillEntities.BillTag.Add(BillTag);
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
                var objTemp = (from x in _BillEntities.BillTag
                               where x.BillTagName == v_Value
                               select x).First();
                _BillEntities.BillTag.Remove(objTemp);
                _BillEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }

        public IEnumerable<BillTagDTO> QueryAll()
        {
            var QBillTag = from x in _BillEntities.BillTag
                         select x;
            var RBillTagDTO = _Mapper.Map<IEnumerable<BillTagDTO>>(QBillTag);
            return RBillTagDTO;
        }

        public BillTagDTO QueryByName(string v_Value)
        {
            var QBillTag = (from x in _BillEntities.BillTag
                          where x.BillTagName == v_Value
                          select x).FirstOrDefault();
            BillTagDTO RBillTagDTO;

            if (QBillTag == null)
                RBillTagDTO = null;
            else
                RBillTagDTO = _Mapper.Map<BillTagDTO>(QBillTag);
            return RBillTagDTO;
        }
    }
}
