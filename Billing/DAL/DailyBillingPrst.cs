using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IDAL;
using Model;

namespace MssqlDAL
{
    public class DailyBillingPrst : IDailyBillingPrst
    {
        private BillingEntities _entities;

        public DailyBillingPrst()
        {
            _entities = new BillingEntities();
        }

        public string Create(DailyBilling v_DailyBilling)
        {
            string sMsg = "";
            try
            {

                _entities.DailyBilling.Add(v_DailyBilling);
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

        public IEnumerable<DailyBilling> QueryAll()
        {
            var QDailyBilling = (from x in _entities.DailyBilling
                         select x);
            return QDailyBilling;
        }

        public DailyBilling QueryByName(string v_Value)
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
            //var QDailyBilling = (from x in _entities.DailyBilling
            //                     where x.Serial == v_Value
            //                    select new
            //                    {
            //                        DailyBilling = x,
            //                        DailyBillingTags = (from y in _entities.DailyBillingTags
            //                                            where y.Serial == x.Serial
            //                                            select y)
            //                    }).FirstOrDefault();
            //DailyBillingDTO RDailyBilling ;

            //if (QDailyBilling == null)
            //    RDailyBilling = null;
            //else
            //{
            //    RDailyBilling = _Mapper.Map<DailyBillingDTO>(QDailyBilling.DailyBilling);
            //    RDailyBilling.BillTags = _Mapper.Map<IEnumerable<DailyBillingTagsDTO>>(QDailyBilling.DailyBillingTags);
            //}

            var Q = (from x in _entities.DailyBilling
                     where x.Serial == v_Value
                     select x).FirstOrDefault();
            
            return Q;
        }

        public string Update(DailyBilling v_DailyBilling)
        {
            string sMsg = "";
            try
            {
                //deal with DailyBilling
                //var Billing = (from x in _entities.DailyBilling
                //               where x.Serial == v_Key
                //               select x).First();
                //var NewBilling = _Mapper.Map<DailyBilling>(v_NewValue);

                //deal with DailyBillingTags
                //var Tags = from x in _entities.DailyBillingTags
                //           where x.Serial == v_Key
                //           select x;
                //var NewTags = _Mapper.Map<IEnumerable<DailyBillingTags>>(v_NewValue.BillTags);

                //_entities.DailyBilling.Remove(Billing);
                //_entities.DailyBillingTags.RemoveRange(Tags);
                //_entities.DailyBilling.Add(NewBilling);
                //_entities.DailyBillingTags.AddRange(NewTags);
                //_entities.SaveChanges();

                var Tags = from x in _entities.DailyBillingTags
                            where x.Serial == v_DailyBilling.Serial
                            select x;

                _entities.Entry<DailyBilling>(v_DailyBilling).State = EntityState.Modified;
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
