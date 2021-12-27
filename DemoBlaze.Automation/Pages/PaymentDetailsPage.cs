using OpenQA.Selenium;
using System;
using System.Threading;

namespace DemoBlaze_Automation.Pages
{
    public class PaymentDetailsPage 
    {
        IWebDriver driver;
        public PaymentDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string EnterAndConfirmPaymentDetails()
        {
            NameField.SendKeys("Tester");
            CardField.SendKeys("Card No");
            PurchaseButton.Click();
            return ThankyouMessage.Text;
        }

        public void EnterAndCancelPaymentDetails()
        {
            NameField.SendKeys("Tester");
            CardField.SendKeys("Card No");
            CloseButton.Click();
        }

        public string ThankyouMessageCheckAndReturn()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
                OrderPlacedOkButton.Click();
                if(driver.Url.Contains("/index.html"))
                {
                    Thread.Sleep(2000);
                }
            }
            catch (Exception e)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
            }
            return driver.Url;
        }

        public IWebElement NameField => driver.FindElement(By.Id("name"));
        public IWebElement CardField => driver.FindElement(By.Id("card"));
        public IWebElement PurchaseButton => driver.FindElement(By.XPath(".//button[contains(.,'Purchase')]"));
        public IWebElement CloseButton => driver.FindElement(By.XPath(".//button[contains(.,'Close')]"));
        public IWebElement OrderPlacedOkButton => driver.FindElement(By.XPath(".//button[contains(.,'OK')]"));
        public IWebElement ThankyouMessage => driver.FindElement(By.XPath(".//h2[contains(.,'Thank you for your purchase!')]"));

    }
}
