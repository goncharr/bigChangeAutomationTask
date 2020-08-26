using BigChangeAutomationFramework.AppConfiguration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace BigChangeAutomationFramework.Helper
{
    public static class DriverOptions
    {
        public static IWebDriver _webdriver { get; set; }
       
        public static IWebDriver GetDriver()
        {
            try
            {

                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--window-size=1920,1080");
                _webdriver = new ChromeDriver(chromeOptions);
                return _webdriver;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Error initializing ChromeWebDriver", ex)
                {

                };
            }
        }

        public static void Navigate()
        {
            var baseUrl = ConfigManager.Common["baseUrl"];
            _webdriver.Navigate().GoToUrl(baseUrl);
        }

        public static void Close()
        {
            _webdriver.Manage().Cookies.DeleteAllCookies();
            _webdriver.Quit();
        }

    }
}
