using BigChangeAutomationFramework.AppConfiguration;
using BigChangeAutomationFramework.Pages;
using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BigChangeAutomationTests.Steps
{
    [Binding]
    public class LogInSteps
    {
        private readonly ILogInPage _loginPage;

        public LogInSteps(ILogInPage loginPage)
        {
            _loginPage = loginPage;
        }

        [Given(@"I have a twitter account")]
        public void GivenIHaveATwitterAccount()
        {
           
        }
        
        [When(@"I login in using my ""(.*)"" and ""(.*)"" values")]
        public void WhenILoginInUsingMyAndValues(string userNameKey, string passwordKey)
        {
            try
            {
                var userNameValue = ConfigManager.Common[$"{userNameKey}"];
                var passwordValue = ConfigManager.Common[$"{passwordKey}"];
                _loginPage.SetEmail(userNameValue);
                _loginPage.SetPassword(passwordValue);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(userNameKey + " or" + passwordKey + " passwordKey" + " has incorect value");
            }
            _loginPage.ClickLogInButton();
        }

        [Then(@"I should see error ""(.*)"" message")]
        public void ThenIShouldSeeErrorMessage(string errorText)
        {
           Assert.IsTrue(_loginPage.IsErrorTextVisible(errorText), "Error text is not visible");
        }

        [Given(@"I'm logged in to twitter")]
        public void GivenIMLoggedInToTwitter()
        {
            WhenILoginInUsingMyAndValues("correctUserName", "correctPassword");
        }

    }
}