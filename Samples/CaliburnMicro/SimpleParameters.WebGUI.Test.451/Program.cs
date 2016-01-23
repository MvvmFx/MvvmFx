using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SimpleParameters.WebGUI.Test
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //DriverTest();
            new SimpleRun();
        }

        private static void DriverTest()
        {
            var driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://www.google.com/");

            // Find the text input element by its name
            var query = driver.FindElement(By.Name("q"));

            // Enter something to search for
            query.SendKeys("Cheese");

            // Now submit the form. WebDriver will find the form for us from the element
            query.Submit();

            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 10 seconds
            var wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Title.ToLower().StartsWith("cheese"); });

            // Should see: "Cheese - Google Search"
            System.Console.WriteLine("Page title is: " + driver.Title);

            //Close the browser
            driver.Quit();
        }
    }
}