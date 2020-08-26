namespace BigChangeAutomationFramework.Pages
{
    public interface ILogInPage
    {
        void SetEmail(string userName);
        void SetPassword(string password);
        void ClickLogInButton();
        bool IsErrorTextVisible(string errorText);
    }
}