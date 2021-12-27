using OpenQA.Selenium;

namespace DemoBlaze_Automation.Pages
{
    public class ViewBasketPage
    {
        public IWebDriver driver { get; }

        public ViewBasketPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool DeleteTheItemAndConfirm()
        {
            bool result = false;
            int noOfItemsInBasket = driver.FindElements(By.CssSelector("a[onclick*='deleteItem']")).Count;
            driver.FindElement(By.CssSelector("#tbodyid>tr:nth-child(1)>td:nth-child(4)>a")).Click();
            int updatedNoOfItemsInBasket = driver.FindElements(By.CssSelector("a[onclick*='deleteItem']")).Count;
            if(updatedNoOfItemsInBasket < noOfItemsInBasket)
            {
                result = true;
            }
            return result;
        }

        public IWebElement PlaceOrderButton => driver.FindElement(By.XPath(".//button[contains(.,'Place Order')]"));
        public IWebElement TotalCostDisplay => driver.FindElement(By.Id("totalp"));
    }
}
