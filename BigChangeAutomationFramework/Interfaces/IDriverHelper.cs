using OpenQA.Selenium;
using System;

namespace BigChangeAutomationFramework.Helper
{
    public interface IDriverHelper
    {
        IWebElement WaitForElementVisible(By by, TimeSpan pollingIntervals, int iterations);
        bool isElementPresent(By locator);
        void WaitElementIsNotPresent(By locator, int iterations, int pollingIntervals);
        IWebElement GetElementFromCollection(By collectionSelector, string value);
        void NavigateToUrl(string url);
    }
}