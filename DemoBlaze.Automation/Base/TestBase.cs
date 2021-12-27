using DemoBlaze_Automation.Factories;
using DemoBlaze_Automation.Pages;
using OpenQA.Selenium;
using System;
using Xunit;
using Xunit.Abstractions;

namespace DemoBlaze_Automation.Base
{
    public class TestBase :  XunitContextBase, IDisposable
    {
        public IWebDriver driver;
        public DemoBlazeStorePage demoBlazeStorePage;
        public PlaceOrderPage placeOrderPage;
        public PaymentDetailsPage paymentDetailsPage;
    
        public TestBase(ITestOutputHelper output): base(output)
        {
            driver = DriverFactory.CreateDriver();

            demoBlazeStorePage = new DemoBlazeStorePage(driver);
            placeOrderPage = new PlaceOrderPage(driver);
            paymentDetailsPage = new PaymentDetailsPage(driver);
        }

        public override void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
