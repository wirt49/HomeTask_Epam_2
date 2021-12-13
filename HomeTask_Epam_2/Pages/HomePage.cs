using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Microsoft.Graph;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace HomeTask_Epam_2.Pages
{
    public class HomePage: BasePage
    {
        
        private readonly WebDriverWait wait;
        private readonly string searchFieldXpath = "//input[@name ='search']";
        public HomePage(IWebDriver driver) : base(driver) { 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        }

        public void Search(string searchedProduct)
        {
            driver.FindElement(By.XPath(searchFieldXpath)).SendKeys(searchedProduct + Keys.Enter);
        }
        
    }
}
