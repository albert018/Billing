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
        public IEnumerable<BillType> Get()
        {
            return _BLL.QueryAll();
        }

        // GET: api/BillType/5
        public BillType Get(string id)
        {
            return _BLL.QueryByName(id);
        }

        // POST: api/BillType
        public string Post(BillType Value)
        {
            return _BLL.Create(Value);
        }

        // PUT: api/BillType/5
        //public void Put(int id, [FromBody]string value)
        //{

        //}

        // DELETE: api/BillType/5
        public string Delete(string id)
        {
            return _BLL.Delete(id);
        }
    }
}
