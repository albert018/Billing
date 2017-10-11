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
    public class BillTagController : ApiController
    {
        BillTagBLL _BillTag = new BillTagBLL();

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var Result = _BillTag.QueryAll();
            if (Result == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no data");
            else
                return Request.CreateResponse(HttpStatusCode.OK,Result);
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(string Id)
        {
            var Result = _BillTag.QueryByName(Id);
            if (Result == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "The data not found");
            else
                return Request.CreateResponse(HttpStatusCode.OK, Result);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(BillTagDTO Value)
        {
            string sMsg = _BillTag.Create(Value);
            if (sMsg == "")
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, sMsg);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(string Id)
        {
            string sMsg= _BillTag.Delete(Id);
            if (sMsg == "")
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, sMsg);
        }

    }
}