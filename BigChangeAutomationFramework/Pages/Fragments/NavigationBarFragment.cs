using BigChangeAutomationFramework.Helper;
using OpenQA.Selenium;
using System;

namespace BigChangeAutomationFramework.Pages.Fragments
{
    public class NavigationBarFragment : INavigationBarFragment
    {
        private readonly IDriverHelper _webdriverHelper;

        private const string FooterButton = "nav [aria-label='{0}']";

        public NavigationBarFragment(IDriverHelper webdriverHelper)
        {
            _webdriverHelper = webdriverHelper;
        }

        public void SelectMenuItem(string menuItem)
        {
            _webdriverHelper.WaitForElementVisible(By.CssSelector(string.Format(FooterButton, menuItem)), TimeSpan.FromMilliseconds(300), 5)?.Click();
        }
    }
}