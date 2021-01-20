using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;
using NewAutomationFramework.Page;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewAutomationFramework.Steps
{
    [Binding]
    class APIPageSteps
    {
        IWebDriver Driver;

        [Given(@"I call promotion API with key '(.*)'")]
        public void GivenICallPromotionAPIWithKey(string APIKey)
        {
            APIPage apiPageObject = new APIPage();
            JObject response = apiPageObject.CallAPIs(APIKey);
            ScenarioContext.Current["response"] = response;
        }

        [Then(@"I validate status '(.*)'")]
        public void ThenIValidateStatus(int status)
        {
            APIPage apiPageObject = new APIPage();
            JObject response = (JObject)ScenarioContext.Current["response"];
            apiPageObject.VerifyApiStatus(status, response);
        }


        [Then(@"I verify response properties for valid request")]
        public void ThenIVerifyResponsePropertiesForValidRequest()
        {
            APIPage apiPageObject = new APIPage();
            JObject apiResponse = (JObject)ScenarioContext.Current["response"];
            Assert.IsNotNull(apiResponse["promotions"].ToString());
            Console.WriteLine(apiResponse["promotions"].ToString());
            Assert.IsNotNull(apiResponse["promotions"][0]["promotionId"]);
            var typeOfPromoId = apiResponse["promotions"][0]["promotionId"].Value<string>().GetType();
            Assert.AreEqual(typeof(string), typeOfPromoId);
            Assert.IsNotNull(apiResponse["promotions"][0]["orderId"]);
            Console.WriteLine(apiResponse["promotions"][0]["orderId"]);
            Assert.IsNotNull(apiResponse["promotions"][0]["promoArea"]);
            Assert.IsNotNull(apiResponse["promotions"][0]["promoType"]);
            var typeOfShowPrice = apiResponse["promotions"][0]["showPrice"].Value<bool>().GetType();
            Assert.AreEqual(typeof(bool), typeOfShowPrice);
            var typeOfShowText = apiResponse["promotions"][0]["showText"].Value<bool>().GetType();
            Assert.AreEqual(typeof(bool), typeOfShowText);
            Assert.IsNotNull(apiResponse["promotions"][0]["localizedTexts"]);
            Assert.IsNotNull(apiResponse["promotions"][0]["localizedTexts"]["ar"]);
            Assert.IsNotNull(apiResponse["promotions"][0]["localizedTexts"]["en"]);
            string[] programType = { "EPISODE", "MOVIE", "SERIES", "SEASON" };
            Assert.IsTrue(programType.Contains(apiResponse["promotions"][0]["properties"][0]["programType"].ToString().ToUpper()));
        }

        [Then(@"I verify response properties for invalid request")]
        public void ThenIVerifyResponsePropertiesForinValidRequest()
        {
            APIPage apiPageObject = new APIPage();
            JObject apiResponse = (JObject)ScenarioContext.Current["response"];
            Assert.IsNotNull(apiResponse["error"]["requestId"].ToString());
            Assert.AreEqual((string)apiResponse["error"]["code"],"8001");
            Assert.AreEqual((string)apiResponse["error"]["message"], "invalid api key");

        }

    }
}
