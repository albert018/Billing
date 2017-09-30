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
        public BillTag Get(string Id)
        {
            return _BillTag.QueryByName(Id);
        }

        // POST api/<controller>
        public string Post(BillTag Value)
        {
            return _BillTag.Create(Value);
        }

        // PUT api/<controller>/5
        //public string Put(string v_sBillTagName)
        //{
        //    var NewValue = new BillTag();
        //    NewValue = this.Request.Content.ReadAsAsync<BillTag>().Result;
        //    return _BillTag.Updte(v_sBillTagName, NewValue);
        //}

        // DELETE api/<controller>/5
        public string Delete(string Id)
        {
            return _BillTag.Delete(Id);
        }

    }
}