using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace BigChangeAutomationFramework.Helper
{
    public class DriverHelper : IDriverHelper
    {
        private readonly IWebDriver _webDriver;


        public DriverHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public virtual bool IsElementVisible(IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IWebElement WaitForElementVisible(By by, TimeSpan pollingIntervals, int iterations)
        {
            try
            {
                for (var index = 0; index < iterations; ++index)
                {
                    if (index.Equals(iterations - 1))
                        throw new Exception();
                    if (!IsElementVisible(_webDriver, by))
                        Thread.Sleep(pollingIntervals);
                    else
                        break;
                }
            }
            catch
            {
                throw new NotImplementedException(by.ToString() + " is not visble");

            }
            return _webDriver.FindElement(by);
        }

        public bool isElementPresent(By locator)
        {
            bool elementLocated = true;
            try
            {
                if (_webDriver.FindElements(locator).Count() != 0)
                {
                    return elementLocated;
                }
            }
            catch (Exception)
            {
                elementLocated = false;
                return elementLocated;
            }

            return elementLocated;
        }

        public virtual ReadOnlyCollection<IWebElement> WaitForElementsPresent(By by, TimeSpan pollingInterval, int iterations)
        {
            try
            {
                if (!isElementPresent(by))
                {
                    for (var index = 0; index < iterations; ++index)
                    {
                        try
                        {
                            if (isElementPresent(by))
                                return _webDriver.FindElements(by);
                        }
                        catch
                        {
                        }

                        Thread.Sleep(pollingInterval);
                    }

                    throw new Exception();
                }

                return _webDriver.FindElements(by);
            }
            catch (Exception)
            {
                throw new NotImplementedException("Elements is not present");
            }
        }

        public void WaitElementIsNotPresent(By locator, int iterations, int pollingIntervals)
        {
            try
            {
                for (var index = 0; index < iterations; ++index)
                {
                    if (index.Equals(iterations - 1))
                        throw new Exception();
                    if (isElementPresent(locator))
                    {
                        Thread.Sleep(pollingIntervals);
                    }
                    else
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Load is not finished");
            }
        }

        public IWebElement GetElementFromCollection(By collectionSelector, string value)
        {
            return WaitForElementsPresent(collectionSelector, TimeSpan.FromMilliseconds(500), 10).FirstOrDefault(item => item.Text.Contains(value));
        }

        public void NavigateToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

    }
}