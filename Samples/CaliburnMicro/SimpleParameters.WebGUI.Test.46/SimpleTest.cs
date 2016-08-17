using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SimpleParameters.WebGUI.Test
{
    [TestFixture]
    public class SimpleTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void TestSeleniumMasterLoadingPage()
        {
            driver.Navigate().GoToUrl("http://www.seleniummaster.com");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}