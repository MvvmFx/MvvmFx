using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SimpleParameters.WebGUI.Test
{
    [SetUpFixture]
    public class SetupAllTests
    {
        public static IWebDriver Driver { get; private set; }

        public static string BaseUrl { get; private set; }

        [SetUp]
        public void Setup()
        {
            Driver = new FirefoxDriver();
            BaseUrl = "http://localhost/";
            Driver.Navigate().GoToUrl(BaseUrl + "/");
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}