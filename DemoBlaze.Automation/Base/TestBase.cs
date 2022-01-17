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
        public ViewBasketPage viewBasketPage;
        public PaymentDetailsPage paymentDetailsPage;
        protected readonly ITestOutputHelper output;

        public TestBase(ITestOutputHelper output): base(output)
        {
            driver = DriverFactory.CreateDriver();

            demoBlazeStorePage = new DemoBlazeStorePage(driver);
            viewBasketPage = new ViewBasketPage(driver);
            paymentDetailsPage = new PaymentDetailsPage(driver);

            this.output = output;
        }

        public override void Dispose()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Dispose();
        }
    }
}
