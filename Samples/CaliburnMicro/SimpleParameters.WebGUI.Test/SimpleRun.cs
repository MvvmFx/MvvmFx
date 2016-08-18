using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SimpleParameters.WebGUI.Test
{
    [SuppressMessage("ReSharper", "EmptyGeneralCatchClause")]
    public class SimpleRun
    {
        // ReSharper disable InconsistentNaming
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        // ReSharper restore InconsistentNaming

        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        public SimpleRun()
        {
            SetupTest();

            // ERROR: Caught exception [ERROR: Unsupported command [setTimeout | 3000 | ]]
            driver.Navigate().GoToUrl(baseURL + "/");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//div[@id='VWG_5']/div/div/div/table/tbody/tr/td/span"))) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//div[@id='VWG_5']/div/div/div/table/tbody/tr/td/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//div[@id='VWG_39']/div/div/div/table/tbody/tr/td/span"))) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='VWG_39']/div/div/div/table/tbody/tr/td/span")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='VWG_38']/div/div/div/table/tbody/tr/td/span")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='VWG_37']/div/div/div/table/tbody/tr/td/span")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='VWG_36']/div/div/div/table/tbody/tr/td/span")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='VWG_35']/div/div/div/table/tbody/tr/td/span")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='VWG_34']/div/div/div/table/tbody/tr/td/span")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='VWG_33']/div/div/div/table/tbody/tr/td/span")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='VWG_32']/div/div/div/table/tbody/tr/td/span")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='VWG_31']/div/div/div/table/tbody/tr/td/span")));
            driver.FindElement(By.XPath("//div[@id='VWG_39']/div/div/div/table/tbody/tr/td/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Type: Gizmox.WebGUI.Forms.BindingContext" == driver.FindElement(By.Id("TRG_27")).Text) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//div[@id='VWG_38']/div/div/div/table/tbody/tr/td/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("DataContext is null" == driver.FindElement(By.Id("TRG_27")).Text) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//div[@id='VWG_37']/div/div/div/table/tbody/tr/td/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Type: Gizmox.WebGUI.Forms.MouseEventArgs\r\nX: 50\r\nY: 11" ==
                        driver.FindElement(By.Id("TRG_27")).Text) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//div[@id='VWG_36']/div/div/div/table/tbody/tr/td/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Type: Gizmox.WebGUI.Forms.Button\r\nName: button4" == driver.FindElement(By.Id("TRG_27")).Text) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//div[@id='VWG_35']/div/div/div/table/tbody/tr/td/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Type: ActionExecutionContext\r\nMethod name: ShowExecutionContext\r\nParameter: $executioncontext" ==
                        driver.FindElement(By.Id("TRG_27")).Text) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//div[@id='VWG_34']/div/div/div/table/tbody/tr/td/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("View\r\nType: SimpleParameters.UI.Views.ButtonView\r\nName: ButtonView\r\nViewModel\r\nType: SimpleParameters.UI.ViewModels.ButtonViewModel\r\nDisplay name: Button Test Screen" ==
                        driver.FindElement(By.Id("TRG_27")).Text) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//div[@id='VWG_33']/div/div/div/table/tbody/tr/td/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("Type: Gizmox.WebGUI.Forms.Button\r\nName: button7" == driver.FindElement(By.Id("TRG_27")).Text)
                        break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            try
            {
                Assert.AreEqual("cb30 cu1 cu1_Disabled", driver.FindElement(By.Id("VWG_32")).GetAttribute("class"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("TRG_29")).SendKeys("12");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("cb27 cb30 cu1" == driver.FindElement(By.Id("VWG_32")).GetAttribute("class")) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//div[@id='VWG_32']/div/div/div/table/tbody/tr/td/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("12" == driver.FindElement(By.Id("TRG_27")).Text) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//div[@id='VWG_31']/div/div/div/table/tbody/tr/td/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("1" == driver.FindElement(By.Id("TRG_27")).Text) break;
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }

            TeardownTest();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}