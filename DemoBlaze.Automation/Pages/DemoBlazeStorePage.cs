using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace DemoBlaze_Automation.Pages
{
    public class DemoBlazeStorePage 
    {
        public IWebDriver driver { get; }
        
        public DemoBlazeStorePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public void AddItem(string item)
        {
            try
            {
                bool result = driver.FindElement(By.XPath($"//a[contains(.,'{item}')]")).Displayed;
                driver.FindElement(By.XPath($"//a[contains(.,'{item}')]")).Click();
            }
            catch (Exception)
            {
                NextButton.Click();
                driver.FindElement(By.XPath($"//a[contains(.,'{item}')]")).Click();
            }
            finally
            {
                AddToCartButton.Click();
                ConfirmAlert();
                StoreCatalogLink.Click();
            }
        }

        public void AddItem(string item1, string item2)
        {
            string[] itemList = { item1, item2 };
            foreach (string item in itemList)
            {
                try
                {
                    bool result = driver.FindElement(By.XPath($"//a[contains(.,'{item}')]")).Displayed;
                    driver.FindElement(By.XPath($"//a[contains(.,'{item}')]")).Click();
                }
                catch (Exception)
                {
                    NextButton.Click();
                    driver.FindElement(By.XPath($"//a[contains(.,'{item}')]")).Click();
                }
                finally
                {
                    AddToCartButton.Click();
                    ConfirmAlert();
                    StoreCatalogLink.Click();
                }
            }
        }

        public void ConfirmAlert()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
                IAlert alert = driver.SwitchTo().Alert();
                if (alert.Text.Contains("Product added"))
                {
                    Thread.Sleep(1000);
                    alert.Accept(); //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                }
            }
            catch (Exception e)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
            }
        }

        public void ScrollAndClick(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click();
        }

        public IWebElement StoreCatalogLink => driver.FindElement(By.Id("nava"));
        public IWebElement MonitorSideMenu => driver.FindElement(By.CssSelector("a[onclick*='monitor']"));
        public IWebElement LaptopSideMenu => driver.FindElement(By.CssSelector("a[onclick*='notebook']"));
        public IWebElement CartMenu => driver.FindElement(By.Id("cartur"));
        public IWebElement LaptopSonyi7Link => driver.FindElement(By.CssSelector("a[href*='idp_=9']"));
        public IWebElement MonitorAsusHDLink => driver.FindElement(By.CssSelector("a[href*='idp_=14']"));
        public IWebElement NextButton => driver.FindElement(By.XPath(".//button[contains(.,'Next')]"));
        public IWebElement PreviousButton => driver.FindElement(By.XPath(".//button[contains(.,'Previous')]"));
        public IWebElement AddToCartButton => driver.FindElement(By.CssSelector("a[onclick^='addToCart']"));
    }
}
