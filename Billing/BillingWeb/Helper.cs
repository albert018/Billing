using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

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
    }
}