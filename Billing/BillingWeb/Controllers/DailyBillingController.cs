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
    public class DailyBillingController : Controller
    {
        private string _sApiAddress = "";
        private string _sApiURI = "";

        public DailyBillingController()
        {
            _sApiAddress = Helper.GetConfig(Helper.ConfigName.WebAPI);
            _sApiURI = Helper.GetConfig(Helper.ConfigName.ApiURI) + "/DailyBilling";
        }

        // GET: DailyBilling
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(_sApiURI).Result;
                return View("DailyBillingIndex",
                    JsonConvert.DeserializeObject<IEnumerable<DailyBilling>>(response.Content.ReadAsStringAsync().Result));
            }
        }

        // GET: DailyBilling/Details/5
        public ActionResult Details(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(string.Format(_sApiURI+ "/{0}", id)).Result;
                return View("DailyBillingDetail",
                    JsonConvert.DeserializeObject<DailyBilling>(response.Content.ReadAsStringAsync().Result));
            }
        }

        // GET: DailyBilling/Create
        public ActionResult Create()
        {
            return View("DailyBillingCreate");
        }

        // POST: DailyBilling/Create
        [HttpPost]
        public ActionResult Create(DailyBilling v_Value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.PostAsJsonAsync<DailyBilling>(_sApiURI, v_Value).Result;
                return RedirectToAction("Index");
            }
        }

        // GET: DailyBilling/Edit/5
        public ActionResult Edit(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(string.Format(_sApiURI + "/{0}", id)).Result;
                return View("DailyBillingEdit",
                    JsonConvert.DeserializeObject<DailyBilling>(response.Content.ReadAsStringAsync().Result));
            }
        }

        // POST: DailyBilling/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, DailyBilling v_Value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.PutAsJsonAsync<DailyBilling>(string.Format(_sApiURI+ "/{0}",id), v_Value).Result;
                return RedirectToAction("Index");
            }
        }

        // GET: DailyBilling/Delete/5
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
