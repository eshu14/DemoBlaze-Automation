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
            chromeOptions.AddArguments("--start-maximised");

            var chromeDriverService = ChromeDriverService.CreateDefaultService(Environment.GetEnvironmentVariable("ChromeWebDriver"));
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromSeconds(120));
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return chromeDriver;
        }
    }
}
