using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using BLL;

namespace BusinessService.Controllers
{
    public class DailyBillingController : ApiController
    {
        private DailyBillingBLL _BLL;

        public DailyBillingController()
        {
            _BLL = new DailyBillingBLL();
        }

        // GET: api/DailyBilling
        public IEnumerable<DailyBilling> Get()
        {
            return _BLL.QueryAll();
        }

        // GET: api/DailyBilling/5
        public DailyBilling Get(string id)
        {
            return _BLL.QueryByName(id);
        }

        // POST: api/DailyBilling
        public string Post(DailyBilling Value)
        {
            return _BLL.Create(Value);
        }

        // PUT: api/DailyBilling/5
        public string Put(string id)
        {
            var Value = Request.Content.ReadAsAsync<DailyBilling>().Result;
            return _BLL.Updte(id, Value);
        }

        // DELETE: api/DailyBilling/5
        public string Delete(string id)
        {
            return _BLL.Delete(id);
        }
    }
}
