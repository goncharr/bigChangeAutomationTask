using BigChangeAutomationFramework.Helper;
using OpenQA.Selenium;
using System;

namespace BigChangeAutomationFramework.Pages
{
    public class LogInPage : ILogInPage
    {
        private readonly IDriverHelper _webdriverHelper;
        
        public LogInPage(IDriverHelper webdriverHelper)
        {
            _webdriverHelper = webdriverHelper;
        }

        private readonly By _userNameInput = By.CssSelector("[dir='auto'] [name='session[username_or_email]");
        private readonly By _passwordInput = By.CssSelector("[dir='auto'] [name='session[password]");
        private readonly By _logInButton = By.XPath("//span[text()='Log in']");
        private readonly By _errorTex = By.CssSelector("[dir='auto'] span");
       

        public void SetEmail(string userName)
        {
            _webdriverHelper.WaitForElementVisible(_userNameInput, TimeSpan.FromMilliseconds(300), 5).SendKeys(userName);
        }

        public void SetPassword(string password)
        {
            _webdriverHelper.WaitForElementVisible(_passwordInput, TimeSpan.FromMilliseconds(300), 5).SendKeys(password);
        }

        public void ClickLogInButton()
        {
            _webdriverHelper.WaitForElementVisible(_logInButton, TimeSpan.FromMilliseconds(300), 5).Click();
        }

        public bool IsErrorTextVisible(string errorText)
        {
            return _webdriverHelper.GetElementFromCollection(_errorTex, errorText).Displayed;
        }
        
    }
}
