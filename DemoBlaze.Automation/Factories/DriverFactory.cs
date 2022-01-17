using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DemoBlaze_Automation.Factories
{
    public class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var chromeOptions = new ChromeOptions();

            // Start maximised
            chromeOptions.AddArguments("--start-maximized");

            var chromeDriverService = ChromeDriverService.CreateDefaultService(Environment.GetEnvironmentVariable("ChromeWebDriver"));
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return chromeDriver;
        }
    }
}
