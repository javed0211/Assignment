using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.IO;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;
using NewAutomationFramework.Steps;

namespace NewAutomationFramework.Hooks
{
    [Binding]
    public class Hooks : BaseSteps
    {
        private static IWebDriver driver;

        //[BeforeScenario]
        //public void SetDriver()
        //{
        //    string broswer = ConfigurationSettings.AppSettings["Browser"];
        //    switch(broswer.ToLower())
        //    {
        //        case "chrome":
        //            driver = ChromeDriver();
        //            break;

        //        case "firefox":
        //            driver = SetFirefoxDriver();
        //            break;

        //        case "ie":
        //            break;

        //        default:
        //            break;
        //    }

        //    ScenarioContext.Current["driver"] = driver;
        //}

        //[AfterScenario]
        //public void CloseBrowser()
        //{
        //    driver = (IWebDriver)ScenarioContext.Current["driver"];
        //    //driver.Close();
        //    driver.Quit();
        //}
    }
}
