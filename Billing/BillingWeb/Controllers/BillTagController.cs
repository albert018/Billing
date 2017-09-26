using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Model;

namespace BillingWeb.Controllers
{
    public class BillTagController : Controller
    {
        private string _sApiAddress = "";
        private string _sApiURI = "";

        public BillTagController()
        {
            _sApiAddress = Helper.GetConfig(Helper.ConfigName.WebAPI);
            _sApiURI = "BillingWebAPI/API/BillTag";
        }

        // GET: BillTag
        public ActionResult Index()
        {
            using (var client= new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(_sApiURI).Result;
                if (response.IsSuccessStatusCode)
                    return View("BillTagIndex", JsonConvert.DeserializeObject<IEnumerable<BillTag>>(response.Content.ReadAsStringAsync().Result));
                else
                    return View("BillTagIndex");
            }
        }

        // GET: BillTag/Details/5
        public ActionResult Details(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(string.Format(_sApiURI+ "/{0}",id)).Result;
                if (response.IsSuccessStatusCode)
                    return View("BillTagDetail", JsonConvert.DeserializeObject<BillTag>(response.Content.ReadAsStringAsync().Result));
                else
                    return View("BillTagDetail");
            }
        }

        // GET: BillTag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillTag/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BillTag/Edit/5
        public ActionResult Edit(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(string.Format(_sApiURI + "/{0}", id)).Result;
                if (response.IsSuccessStatusCode)
                    return View("BillTagEdit", JsonConvert.DeserializeObject<BillTag>(response.Content.ReadAsStringAsync().Result));
                else
                    return View("BillTagEdit");
            }
        }

        // POST: BillTag/Edit/5
        [HttpPost]
        public ActionResult Edit(BillTag Model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.PutAsJsonAsync<BillTag>(_sApiURI, Model).Result;
                return RedirectToAction("Index");
            }
        }

        // GET: BillTag/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BillTag/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
