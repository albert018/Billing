using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Model;

namespace BillingWeb.Controllers
{
    public class BillTypeController : Controller
    {
        private string _sApiAddress = "";
        private string _sApiURI = "";

        public BillTypeController()
        {
            _sApiAddress = Helper.GetConfig(Helper.ConfigName.WebAPI);
            _sApiURI = Helper.GetConfig(Helper.ConfigName.ApiURI) + "/BillType";
        }

        // GET: BillType
        public ActionResult Index()
        {
            using (var client= new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(_sApiURI).Result;
                return View("BillTypeIndex",
                    JsonConvert.DeserializeObject<IEnumerable<BillType>>(response.Content.ReadAsStringAsync().Result));
            }
        }

        // GET: BillType/Details/5
        public ActionResult Details(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(string.Format(_sApiURI + "/{0}",id)).Result;
                return View("BillTypeDetail",
                    JsonConvert.DeserializeObject<BillType>(response.Content.ReadAsStringAsync().Result));
            }
        }

        public ActionResult Create()
        {
            return View("BillTypeCreate");
        }

        // GET: BillType/Create
        [HttpPost]
        public ActionResult Create(BillType v_Value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.PostAsJsonAsync(_sApiURI, v_Value).Result;
                return RedirectToAction("Index");
            }
        }

        // GET: BillType/Delete/5
        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.DeleteAsync(string.Format(_sApiURI + "/{0}", id)).Result;
                return RedirectToAction("Index");
            }
        }
    }
}
