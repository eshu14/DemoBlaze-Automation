﻿using OpenQA.Selenium;
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
        
        public void AddItemsToBasket(string Item)
        {
            int i;
            if(Item.Equals("Sony vaio i7"))
            {
                i = 9;
                LaptopSideMenu.Click();
                AddItem(i);
            }
            else if(Item.Equals("ASUS Full HD"))
            {
                i= 14;
                MonitorSideMenu.Click();
                AddItem(i);
            }

        }

        public void AddItem(int i)
        {
            driver.FindElement(By.CssSelector($"a[href*='idp_={i}']")).Click();
            AddToCartButton.Click();
            ConfirmAlert();
            StoreCatalogLink.Click();
        }

        public void ConfirmAlert()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
                IAlert alert = driver.SwitchTo().Alert();
                if (alert.Text.Contains("Product added"))
                {
                    Thread.Sleep(500);
                    alert.Accept();
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
