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
    public class DailyBillingPrst : IDailyBillingPrst
    {
        private BillingEntities _entities;
        private IMapper _Mapper;

        public DailyBillingPrst()
        {
            _entities = new BillingEntities();
            _Mapper = MapperFactory.GetMapper();
        }

        public string Create(DailyBillingDTO v_Value)
        {
            string sMsg = "";
            try
            {
                var DailyBilling = _Mapper.Map<DailyBilling>(v_Value);
                var DailyBillingTags = _Mapper.Map<IEnumerable<DailyBillingTags>>(v_Value.BillTags);

                _entities.DailyBilling.Add(DailyBilling);
                _entities.DailyBillingTags.AddRange(DailyBillingTags);
                _entities.SaveChanges();
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
                var objTemp = (from x in _entities.DailyBilling
                               where x.Serial == v_Value
                               select x).First();
                _entities.DailyBilling.Remove(objTemp);
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }

        public IEnumerable<DailyBillingDTO> QueryAll()
        {
            var QDailyBilling = (from x in _entities.DailyBilling
                         select x);
            var RDailiBilling = _Mapper.Map<IEnumerable<DailyBillingDTO>>(QDailyBilling);
            return RDailiBilling;
        }

        public DailyBillingDTO QueryByName(string v_Value)
        {
            ////deal with DailyBilling
            //var QDailyBilling = (from x in _entities.DailyBilling
            //                     where x.Serial == v_Value
            //                     select x).FirstOrDefault();
            //var RDailyBilling = _Mapper.Map<DailyBillingDTO>(QDailyBilling);

            ////deal with DailyBillingTags
            //var QDailyBillingTags = from x in _entities.DailyBillingTags
            //                        where x.Serial == v_Value
            //                        select x;
            //var RDailyBillingTags = _Mapper.Map<IEnumerable<DailyBillingTagsDTO>>(QDailyBillingTags);
            //RDailyBilling.BillTags = RDailyBillingTags;

            //to avoid connect to the SQL two times, so combine together
            var QDailyBilling = (from x in _entities.DailyBilling
                                 where x.Serial == v_Value
                                select new
                                {
                                    DailyBilling = x,
                                    DailyBillingTags = (from y in _entities.DailyBillingTags
                                                        where y.Serial == x.Serial
                                                        select y)
                                }).FirstOrDefault();
            DailyBillingDTO RDailyBilling ;

            if (QDailyBilling == null)
                RDailyBilling = null;
            else
            {
                RDailyBilling = _Mapper.Map<DailyBillingDTO>(QDailyBilling.DailyBilling);
                RDailyBilling.BillTags = _Mapper.Map<IEnumerable<DailyBillingTagsDTO>>(QDailyBilling.DailyBillingTags);
            }
            
            return RDailyBilling;
        }

        public string Update(string v_Key, DailyBillingDTO v_NewValue)
        {
            string sMsg = "";
            try
            {
                //deal with DailyBilling
                var Billing = (from x in _entities.DailyBilling
                               where x.Serial == v_Key
                               select x).First();
                var NewBilling = _Mapper.Map<DailyBilling>(v_NewValue);

                //deal with DailyBillingTags
                var Tags = from x in _entities.DailyBillingTags
                           where x.Serial == v_Key
                           select x;
                var NewTags = _Mapper.Map<IEnumerable<DailyBillingTags>>(v_NewValue.BillTags);

                _entities.DailyBilling.Remove(Billing);
                _entities.DailyBillingTags.RemoveRange(Tags);
                _entities.DailyBilling.Add(NewBilling);
                _entities.DailyBillingTags.AddRange(NewTags);
                _entities.SaveChanges();
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
            }
            return sMsg;
        }
    }
}
