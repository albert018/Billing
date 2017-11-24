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
                if (response.IsSuccessStatusCode)
                    return View("DailyBillingIndex", response.Content.ReadAsAsync<IEnumerable<DailyBillingDTO>>().Result);
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "DailyBilling", "Index"));
            }
        }

        // GET: DailyBilling/Details/5
        public ActionResult Details(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(string.Format(_sApiURI+ "/{0}", id)).Result;
                if (response.IsSuccessStatusCode)
                    return View("DailyBillingDetail", response.Content.ReadAsAsync<DailyBillingDTO>().Result);
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "DailyBilling", "Details"));
            }
        }

        // GET: DailyBilling/Create
        public ActionResult Create()
        {
            return View("DailyBillingCreate");
        }

        // POST: DailyBilling/Create
        [HttpPost]
        public ActionResult Create(DailyBillingDTO v_Value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.PostAsJsonAsync(_sApiURI, v_Value).Result;
                if(response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "DailyBilling", "Create"));
            }
        }

        // GET: DailyBilling/Edit/5
        public ActionResult Edit(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(string.Format(_sApiURI + "/{0}", id)).Result;
                if (response.IsSuccessStatusCode)
                    return View("DailyBillingEdit", response.Content.ReadAsAsync<DailyBillingDTO>().Result);
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "DailyBilling", "Edit(Get)"));
            }
        }

        // POST: DailyBilling/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, DailyBillingDTO v_Value)
        {
            if (!ModelState.IsValid)
                return View("DailyBillingEdit");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.PutAsJsonAsync<DailyBillingDTO>(string.Format(_sApiURI + "/{0}", id), v_Value).Result;
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "DailyBilling", "Edit(Post)"));
            }
        }

        // GET: DailyBilling/Delete/5
        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.DeleteAsync(string.Format(_sApiURI + "/{0}", id)).Result;
                if(response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "DailyBilling", "Delete"));
            }
        }
    }
}
