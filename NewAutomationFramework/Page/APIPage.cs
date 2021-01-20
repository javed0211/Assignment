using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Utilities;


namespace NewAutomationFramework.Page
{
    public class APIPage
    {

        private static readonly log4net.ILog log =
   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public JObject CallAPIs(string apiKey)
        {
            APIUtility apiObject = new APIUtility();
            JObject response = null;
            response = apiObject.getResponseFromPOSTAPI(apiKey);
            return response;
        }

        public bool VerifyApiStatus(int status, JObject response)
        {
            IRestResponse responseFromAPI = (IRestResponse)ScenarioContext.Current["responseUnParsed"];
            if ((int)responseFromAPI.StatusCode == status)
                return true;
            else
                return false;


        }
    }
}
