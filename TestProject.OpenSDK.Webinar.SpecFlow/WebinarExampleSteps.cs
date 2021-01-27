using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject.OpenSDK.Drivers.Web;

namespace TestProject.OpenSDK.Webinar.SpecFlow
{
    [Binding]
    public class WebinarExampleSteps
    {
        /// <summary>
        /// The TestProject ChromeDriver instance to be used in this test class.
        /// </summary>
        private ChromeDriver driver;

        /// <summary>
        /// Start a new browser session before each scenario.
        /// </summary>
        [Before]
        public void StartBrowser()
        {
            this.driver = new ChromeDriver();
        }

        /// <summary>
        /// Implementation of the 'Given' step.
        /// </summary>
        /// <param name="firstName">The first name of the user wanting to log in to the TestProject demo application.</param>
        [Given(@"(.+) wants to use the TestProject demo application")]
        public void GivenWantsToUseTheTestProjectDemoApplication(string firstName)
        {
            this.driver.Navigate().GoToUrl("https://example.testproject.io");
        }

        /// <summary>
        /// Implementation of the 'When' step.
        /// </summary>
        /// <param name="username">The username to be provided when logging in.</param>
        /// <param name="password">The password to be provided when logging in.</param>
        [When(@"s?he logs in with username (.+) and password (.+)")]
        public void WhenTheyLogInWithUserNameAndPassword(string username, string password)
        {
            this.driver.FindElement(By.CssSelector("#name")).SendKeys(username);
            this.driver.FindElement(By.CssSelector("#password")).SendKeys(password);
            this.driver.FindElement(By.CssSelector("#login")).Click();
        }

        /// <summary>
        /// Implementation of the 'Then' step.
        /// </summary>
        [Then(@"s?he gains access to the secure part of the application")]
        public void ThenTheyGainAccessToTheSecurePartOfTheApplication()
        {
            Assert.IsTrue(this.driver.FindElement(By.CssSelector("#greetings")).Displayed);
        }

        /// <summary>
        /// Close the browser after each scenario.
        /// </summary>
        [After]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }
    }
}
