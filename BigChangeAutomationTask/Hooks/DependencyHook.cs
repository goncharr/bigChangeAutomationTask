using BoDi;
using TechTalk.SpecFlow;
using BigChangeAutomationFramework.Pages;
using BigChangeAutomationFramework.Helper;
using System.Diagnostics;
using BigChangeAutomationFramework.Pages.Fragments;

namespace BigChangeAutomationTests.Hooks
{
    [Binding]
    public sealed class DependencyHook
    {
        /// <summary>
        /// For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        /// </summary>

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext scenarioContext;

        public DependencyHook(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            this.scenarioContext = scenarioContext;
        }


        [BeforeScenario]
        public void BeforeTestRun()
        {
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }

            var _webDriver = DriverOptions.GetDriver();
            DriverOptions.Navigate();

            _objectContainer.RegisterInstanceAs(_webDriver);
            _objectContainer.RegisterTypeAs<LogInPage, ILogInPage>();
            _objectContainer.RegisterTypeAs<DriverHelper, IDriverHelper>();
            _objectContainer.RegisterTypeAs<NavigationBarFragment, INavigationBarFragment>();
            _objectContainer.RegisterTypeAs<HomePage, IHomePage>();
            _objectContainer.RegisterTypeAs<Generator, IGenerator>();
        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            DriverOptions.Close();
        }
    
    }
}