using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;

namespace BillingWeb
{
    public class Helper
    {
        public class ConfigName
        {
            public static string WebAPI = "WebAPI";
            public static string ApiURI = "ApiURI";
        }

        public static string GetConfig(string v_sValue)
        {
            return ConfigurationManager.AppSettings[v_sValue].ToString();
        }

        public static HandleErrorInfo GetHandleErrorInfo(HttpResponseMessage v_Response, string v_sControllerName, string v_sActionName)
        {
            string sResponse = v_Response.Content.ReadAsStringAsync().Result;
            return GetHandleErrorInfo(sResponse, v_sControllerName, v_sActionName);
        }

        public static HandleErrorInfo GetHandleErrorInfo(string v_sErrorMsg,string v_sControllerName,string v_sActionName)
        {
            return new HandleErrorInfo(new Exception(v_sErrorMsg), v_sControllerName, v_sActionName);
        }
    }
}