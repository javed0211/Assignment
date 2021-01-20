using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace Utilities
{
    public class APIUtility
    {
        private static readonly log4net.ILog log =
   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public JObject getResponseFromPOSTAPI(string apiKey)
        {
            JObject resPonseContent = null;
            var client = new RestClient("http://api.intigral-ott.net/popcorn-api-rs-7.9.10/v1/promotions?apikey="+apiKey+"");
            var request = new RestRequest(Method.GET);
            try
            {
                var response = client.Execute(request);
                ScenarioContext.Current["responseUnParsed"] = response;
                log.Info(response.Content);
                resPonseContent = JObject.Parse(response.Content);
                ScenarioContext.Current["response"] = resPonseContent;
            }
            catch (Exception e)
            {
                log.Error("Unable to make request " + e.Message);
            }
            return resPonseContent;
        }

    }
}


