using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewAutomationFramework.Steps
{
    public class BaseSteps
    {
        public static IWebDriver driver;


        public IWebDriver SetDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    driver = ChromeDriver();
                    break;
                case "firefox":
                    driver = SetFirefoxDriver();
                    break;
                default:
                    break;
            }
            return driver;
        }

        public IWebDriver ChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments(
             "--disable-extensions",
             "--disable-features",
             "--disable-popup-blocking",
             "--disable-settings-window",
             "--disable-impl-side-painting",
             "--enable-javascript",
             "--start-maximized",
             "--no-sandbox",
             //"--headless",
             "--disable-gpu",
             "--dump-dom",
             "test-type=browser",
             "disable-infobars",
             "test-type",
             "--enable-automation");
            options.AcceptInsecureCertificates = true;
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            string currentDir_location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            driver = new ChromeDriver(currentDir_location, options);

            return driver;
        }


        public IWebDriver SetFirefoxDriver()
        {
            string currentDir_location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new FirefoxDriver(currentDir_location);

            return driver;
        }
    }
}
