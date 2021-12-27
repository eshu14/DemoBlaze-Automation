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

        public void ThankyouMessageCheckAndReturn()
        {
                ThankMessageOkButton.Click();
                if(PlaceOrderForm.Displayed)
                    PlaceOrderFormCloseButton.Click();
        }

        public IWebElement NameField => driver.FindElement(By.Id("name"));
        public IWebElement CardField => driver.FindElement(By.Id("card"));
        public IWebElement PurchaseButton => driver.FindElement(By.XPath(".//button[contains(.,'Purchase')]"));
        public IWebElement CloseButton => driver.FindElement(By.XPath(".//button[contains(.,'Close')]"));
        public IWebElement ThankMessageOkButton => driver.FindElement(By.XPath(".//button[contains(.,'OK')]"));
        public IWebElement ThankyouMessage => driver.FindElement(By.XPath(".//h2[contains(.,'Thank you for your purchase!')]"));
        public IWebElement PlaceOrderForm => driver.FindElement(By.Id("orderModalLabel"));
        public IWebElement PlaceOrderFormCloseButton => driver.FindElement(By.ClassName("close"));

    }
}
