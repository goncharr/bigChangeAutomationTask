namespace BigChangeAutomationFramework.Pages
{
    public interface IHomePage
    {
        bool IsTimelineVisible();
        void TypeTweetValue(string tweetValue);
        void PostTweet(string buttonName);
        bool IsTweetVisible(string tweetValue);
        void OpenUserMenu();
        void SelectLogOutItem();
        void OpenAcountUrl(string url);
        bool IsTweetsVisible();
    }
}