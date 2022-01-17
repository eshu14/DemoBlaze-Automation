using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace DemoBlaze_Automation.Pages
{
    public class ViewBasketPage
    {
        public IWebDriver driver { get; }

        public ViewBasketPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool DeleteTheItemAndConfirm(int itemPositionToRemove)
        {
            bool result = false;
            Thread.Sleep(1000);
            int noOfItemsInBasket = driver.FindElements(By.CssSelector("a[onclick*='deleteItem']")).Count;
            Console.WriteLine("noOfItemsInBasket "+noOfItemsInBasket);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            string itemRemovedFromBasket = driver.FindElement(By.CssSelector($"#tbodyid>tr:nth-child({itemPositionToRemove})>td:nth-child(4)>a")).Text;
            wait.Until(driver =>  driver.FindElement(By.CssSelector($"#tbodyid>tr:nth-child({itemPositionToRemove})>td:nth-child(4)>a"))).Click();
            Thread.Sleep(1000);
            Console.WriteLine(itemRemovedFromBasket);
            int updatedNoOfItemsInBasket = driver.FindElements(By.CssSelector("a[onclick*='deleteItem']")).Count;
            Console.WriteLine(updatedNoOfItemsInBasket);
            if (updatedNoOfItemsInBasket < noOfItemsInBasket)
            {
                result = true;
            }
            Console.WriteLine(result);
            return result;
        }

        public IWebElement PlaceOrderButton => driver.FindElement(By.XPath(".//button[contains(.,'Place Order')]"));
        public IWebElement TotalCostDisplay => driver.FindElement(By.Id("totalp"));
    }
}
