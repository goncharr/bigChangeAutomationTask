using BigChangeAutomationFramework.Pages;
using BigChangeAutomationFramework.Pages.Fragments;
using BigChangeAutomationFramework.Helper;
using TechTalk.SpecFlow;
using NUnit.Framework;
using BigChangeAutomationFramework.AppConfiguration;

namespace BigChangeAutomationTests.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private readonly IHomePage _homePagePage;
        private readonly INavigationBarFragment _navigationBarFragment;
        private readonly IGenerator _generator;
        private readonly ScenarioContext scenarioContext;

        public HomePageSteps(IHomePage homePagePage, INavigationBarFragment navigationBarFragment, IGenerator generator, ScenarioContext scenarioContext)
        {
            _homePagePage = homePagePage;
            _navigationBarFragment = navigationBarFragment;
            _generator = generator;
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I type any random text")]
        public void GivenITypeAnyRandomText()
        {
            var tweetValue = _generator.GetRandomString();
            scenarioContext.Set(tweetValue, "TweetValue");
            _homePagePage.TypeTweetValue(tweetValue);
        }
        
        [When(@"I click ""(.*)"" button")]
        public void WhenIClickButton(string buttonName)
        {
            _homePagePage.PostTweet(buttonName);
        }

        [Then(@"I should see my tweet in ""(.*)""")]
        public void ThenIShouldSeeMyTweetIn(string menuItem)
        {
            var tweetValue = scenarioContext["TweetValue"].ToString();
            _navigationBarFragment.SelectMenuItem(menuItem);
            Assert.IsTrue(_homePagePage.IsTweetVisible(tweetValue), tweetValue + " wasn't added");
        }

        [When(@"I login click LogOut button")]
        public void WhenILoginClickLogOutButton()
        {
            _homePagePage.OpenUserMenu();
        }

        [Then(@"I should see my twitter timeline")]
        public void ThenIShouldSeeMyTwitterTimeline()
        {
            var accountUrl = ConfigManager.Common["baseAccountUrl"];
            _homePagePage.SelectLogOutItem();
            _homePagePage.OpenAcountUrl(accountUrl);
            Assert.IsTrue(_homePagePage.IsTweetsVisible(), "Tweets are not visible");
        }

    }
}