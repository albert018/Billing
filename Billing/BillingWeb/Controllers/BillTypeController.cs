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
            _sApiURI = Helper.GetConfig(Helper.ConfigName.ApiURI) + "/BillTypeDTO";
        }

        // GET: BillType
        public ActionResult Index()
        {
            using (var client= new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(_sApiURI).Result;
                if (response.IsSuccessStatusCode)
                    return View("BillTypeIndex", response.Content.ReadAsAsync<IEnumerable<BillTypeDTO>>().Result);
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "BillType", "Index"));
            }
        }

        // GET: BillType/Details/5
        public ActionResult Details(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.GetAsync(string.Format(_sApiURI + "/{0}",id)).Result;
                if (response.IsSuccessStatusCode)
                    return View("BillTypeDetail", response.Content.ReadAsAsync<BillTypeDTO>().Result);
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "BillType", "Details"));
            }
        }

        public ActionResult Create()
        {
            return View("BillTypeCreate");
        }

        // GET: BillType/Create
        [HttpPost]
        public ActionResult Create(BillTypeDTO v_Value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.PostAsJsonAsync(_sApiURI, v_Value).Result;
                if(response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "BillType", "Create"));
            }
        }

        // GET: BillType/Delete/5
        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_sApiAddress);
                var response = client.DeleteAsync(string.Format(_sApiURI + "/{0}", id)).Result;
                if(response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View("Error", Helper.GetHandleErrorInfo(response, "BillType", "Delete"));
            }
        }
    }
}
