using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.OpenSDK.Drivers.Web;

namespace TestProject.OpenSDK.Webinar.Examples
{
    public class Examples
    {
        private ChromeDriver _driver;

        public ChromeDriver driver
        {
            get
            {
                System.Threading.Thread.Sleep(500);
                return this._driver;
            }

            set
            {
                this._driver = value;
            }
        }

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver(projectName: "Webinar demo project", jobName: "Webinar demo job");
            this.driver.Report().DisableRedaction(true);
        }

        [Test]
        public void LoginUsingCorrectCredentials_CheckGreetingsMessage_ShouldBeDisplayed()
        {
            this.driver.Navigate().GoToUrl("https://example.testproject.io");

            this.driver.FindElement(By.CssSelector("#name")).SendKeys("John Smith");
            this.driver.FindElement(By.CssSelector("#password")).SendKeys("12345");
            this.driver.FindElement(By.CssSelector("#login")).Click();

            Assert.IsTrue(this.driver.FindElement(By.CssSelector("#greetings")).Displayed);
        }

        [Test]
        public void LoginUsingCorrectCredentials_TryAndFindElementWithIncorrectLocator_ShouldBeReportedAsError()
        {
            this.driver.Navigate().GoToUrl("https://example.testproject.io");

            this.driver.FindElement(By.CssSelector("#name")).SendKeys("John Smith");
            this.driver.FindElement(By.CssSelector("#password")).SendKeys("12345");
            this.driver.FindElement(By.CssSelector("#login")).Click();

            this.driver.FindElement(By.CssSelector("#doesnotexist"));
        }

        [TearDown]
        public void CloseBrowser()
        {
           this.driver.Quit();
        }
    }
}