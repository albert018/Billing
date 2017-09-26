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
        public IEnumerable<BillTag> Get()
        {
            return _BillTag.QueryAll();
        }

        // GET api/<controller>/5
        public BillTag Get(string id)
        {
            return _BillTag.QueryByName(id);
        }

        // POST api/<controller>
        public string Post(BillTag v_Value)
        {
            
            return _BillTag.Create(v_Value);
        }

        // PUT api/<controller>/5
        public string Put(string v_sBillTagName, BillTag v_NewValue)
        {
            return _BillTag.Updte(v_sBillTagName, v_NewValue);
        }

        // DELETE api/<controller>/5
        public string Delete(BillTag v_Value)
        {
            return _BillTag.Delete(v_Value);
        }
    }
}