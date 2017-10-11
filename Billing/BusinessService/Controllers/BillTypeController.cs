using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Model;

namespace BusinessService.Controllers
{
    public class BillTypeController : ApiController
    {
        BillTypeBLL _BLL = new BillTypeBLL();

        // GET: api/BillType
        public HttpResponseMessage Get()
        {
            var Result = _BLL.QueryAll();
            if (Result == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no data");
            else
                return Request.CreateResponse(HttpStatusCode.OK, Result);
        }

        // GET: api/BillType/5
        public HttpResponseMessage Get(string id)
        {
            var Result = _BLL.QueryByName(id);
            if (Result == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "The data not found");
            else
                return Request.CreateResponse(HttpStatusCode.OK, Result);
        }

        // POST: api/BillType
        public HttpResponseMessage Post(BillTypeDTO Value)
        {
            string sMsg = _BLL.Create(Value);
            if (sMsg == "")
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, sMsg);
        }

        // DELETE: api/BillType/5
        public HttpResponseMessage Delete(string id)
        {
            string sMsg = _BLL.Delete(id);
            if (sMsg == "")
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, sMsg);
        }
    }
}
