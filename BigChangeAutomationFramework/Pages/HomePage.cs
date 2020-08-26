using BigChangeAutomationFramework.Helper;
using OpenQA.Selenium;
using System;

namespace BigChangeAutomationFramework.Pages
{
    public class HomePage : IHomePage
    {
        private readonly IDriverHelper _webdriverHelper;
        private readonly IGenerator _generator;

        public HomePage(IDriverHelper webdriverHelper, IGenerator generator)
        {
            _webdriverHelper = webdriverHelper;
            _generator = generator;
        }

        private readonly By _timeLineSection = By.CssSelector("[aria-label='Timeline: Your Home Timeline']");
        private readonly By _tweetItems = By.CssSelector("[data-testid='tweet']");
        private readonly By _tweetButton = By.CssSelector("[data-testid='tweetButtonInline'] span");
        private readonly By _tweetTextBox = By.CssSelector("[aria-label='Tweet text']");
        private readonly By _tweetsList = By.CssSelector("[data-testid='tweet'] [dir='auto'] span");
        private readonly By _userMenuButton = By.CssSelector("[data-testid='SideNav_AccountSwitcher_Button']");
        private readonly By _logOutUserMenuButton = By.CssSelector("[data-testid='AccountSwitcher_Logout_Button']");

        public bool IsTimelineVisible()
        {
            _webdriverHelper.WaitForElementVisible(_tweetButton, TimeSpan.FromMilliseconds(300), 5);
            return _webdriverHelper.isElementPresent(_timeLineSection);
        }

        public void TypeTweetValue(string tweetValue)
        {
           _webdriverHelper.WaitForElementVisible(_tweetTextBox, TimeSpan.FromMilliseconds(300), 5).Click();
           _webdriverHelper.WaitForElementVisible(_tweetTextBox, TimeSpan.FromMilliseconds(300), 5).SendKeys(tweetValue);
        }

        public void PostTweet(string buttonName) 
        {
            _webdriverHelper.GetElementFromCollection(_tweetButton, buttonName).Click();
        }

        public bool IsTweetVisible(string tweetValue)
        {
            _webdriverHelper.WaitElementIsNotPresent(By.CssSelector("viewBox"), 7, 300);
           return _webdriverHelper.GetElementFromCollection(_tweetsList, tweetValue).Displayed;
        }

        public void OpenUserMenu()
        {
            _webdriverHelper.WaitForElementVisible(_userMenuButton, TimeSpan.FromMilliseconds(300), 5).Click();
        }

        public void SelectLogOutItem()
        {
            _webdriverHelper.WaitForElementVisible(_logOutUserMenuButton, TimeSpan.FromMilliseconds(300), 5).Click();
        }

        public void OpenAcountUrl(string url)
        {
            _webdriverHelper.NavigateToUrl(url);
        }

        public bool IsTweetsVisible()
        {
           return _webdriverHelper.WaitForElementVisible(_tweetItems, TimeSpan.FromMilliseconds(500), 5).Displayed;
        }
    }
}