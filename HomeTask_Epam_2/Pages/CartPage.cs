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
    public class CartPage: BasePage
    {
        readonly Int32 timeout = 10000;
        private readonly By cartButtonXpath = By.XPath("//button[@class ='header__button ng-star-inserted header__button--active']");
        private readonly By cartSumXpath = By.XPath("//div[@class = 'cart-receipt__sum']/div/span");
        public CartPage(IWebDriver driver) : base(driver) { }

        public void OpenCart()
        {
            driver.FindElement(cartButtonXpath).Click();
        }

        public int GetCartSum()
        {
            var sum = driver.FindElement(cartSumXpath).Text;
            int value;
            int.TryParse(string.Join("", sum.Where(c => char.IsDigit(c))), out value);
            return value;
        }

        public void LoadComplete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}
