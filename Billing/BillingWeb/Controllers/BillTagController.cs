using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net;
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
                    return View("BillTagIndex", response.Content.ReadAsAsync<IEnumerable<BillTagDTO>>().Result);
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "BillTag", "Index"));
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
                    return View("BillTagDetail", response.Content.ReadAsAsync<BillTagDTO>().Result);
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "BillTag", "Details"));
            }
        }

        // GET: BillTag/Create
        public ActionResult Create()
        {
            return View("BillTagCreate");
        }

        // POST: BillTag/Create
        [HttpPost]
        public ActionResult Create(BillTagDTO v_Value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.PostAsJsonAsync(_sApiURI, v_Value).Result;
                if(response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "BillTag", "Create"));
            }
        }

        // GET: BillTag/Delete/5
        public ActionResult Delete(string Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.DeleteAsync(string.Format(_sApiURI + "/{0}", Id)).Result;
                if(response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "BillTag", "Delete"));
            }
        }

        
    }
}
