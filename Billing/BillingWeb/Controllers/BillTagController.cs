using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
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
            _sApiURI = Helper.GetConfig(Helper.ConfigName.ApiURI)+"/BillTag";
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
            return View("BillTagCreate");
        }

        // POST: BillTag/Create
        [HttpPost]
        public ActionResult Create(BillTag v_Value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.PostAsJsonAsync(_sApiURI, v_Value).Result;
                //var response = client.PostAsync<BillTag>(_sApiURI, v_Value, new JsonMediaTypeFormatter());
                return RedirectToAction("Index");
            }
        }

        // POST: BillTag/Edit/5
        //public ActionResult Edit(BillTag Model)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(_sApiAddress);
        //        var response = client.PutAsJsonAsync<BillTag>(_sApiURI, Model).Result;
        //        return RedirectToAction("Index");
        //    }
        //}

        // GET: BillTag/Delete/5
        public ActionResult Delete(string Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.DeleteAsync(string.Format(_sApiURI + "/{0}", Id)).Result;
                return RedirectToAction("Index");
            }
        }

        
    }
}
