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
        public HttpResponseMessage Get()
        {
            var Result = _BLL.QueryAll();
            if (Result == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no data");
            else
                return Request.CreateResponse(HttpStatusCode.OK, Result);
        }

        // GET: api/DailyBilling/5
        public HttpResponseMessage Get(string id)
        {
            var Result = _BLL.QueryByName(id);
            if (Result == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "The data not found");
            else
                return Request.CreateResponse(HttpStatusCode.OK, Result);
        }

        // POST: api/DailyBilling
        public HttpResponseMessage Post(DailyBilling Value)
        {
            string sMsg = _BLL.Create(Value);
            if (sMsg == "")
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, sMsg);
        }

        // PUT: api/DailyBilling/5
        public HttpResponseMessage Put(string id)
        {
            var Value = Request.Content.ReadAsAsync<DailyBilling>().Result;
            string sMsg = _BLL.Updte(id, Value);
            if (sMsg == "")
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, sMsg);
        }

        // DELETE: api/DailyBilling/5
        public HttpResponseMessage Delete(string id)
        {
            string sMsg = _BLL.Delete(id);
            if (sMsg == "")
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, sMsg);
        }
    }
}
