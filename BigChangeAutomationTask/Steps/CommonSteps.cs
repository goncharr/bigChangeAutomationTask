using BigChangeAutomationFramework.Pages;
using BigChangeAutomationFramework.Pages.Fragments;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BigChangeAutomationTests.Steps
{
    [Binding]
    public class CommonSteps
    {
        private readonly INavigationBarFragment _navigationBarFragment;
        private readonly IHomePage _homePage;

        public CommonSteps(INavigationBarFragment navigationBarFragment, IHomePage homePage)
        {
            _navigationBarFragment = navigationBarFragment;
            _homePage = homePage;
        }

        [Then(@"I should see my twitter feed")]
        public void ThenIShouldSeeMyTwitterFeed()
        {
            Assert.IsTrue(_homePage.IsTimelineVisible(), "Timeline is not visible");
        }
    }
}
