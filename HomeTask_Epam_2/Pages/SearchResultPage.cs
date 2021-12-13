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
using System.Threading.Tasks;

namespace HomeTask_Epam_2.Pages
{
    public class SearchResultPage: BasePage
    {
        Int32 timeout = 100000;
        private readonly By expensiveSortXpath = By.XPath("//option[contains(@value, 'expensive')]");
        private readonly By firstElementOnSortedPageXpath = By.XPath("//div[@class = 'goods-tile__inner']");
        private readonly By addToCartButtonXpath = By.XPath("//app-buy-button[@class = 'toOrder ng-star-inserted']");
        private IWebElement elemFirstResult;


        public SearchResultPage(IWebDriver driver): base(driver) { }

        async void async_delay()
        {
            await Task.Delay(50);
        }

        public void ExpensiveSort()
        {
            driver.FindElement(expensiveSortXpath).Click();
        }

        public void AddToCartMostExpensiveProd()
        {
            driver.FindElement(addToCartButtonXpath).Click();
        }
        public void LoadComplete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public CartPage СlickSearchResults()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            elemFirstResult.Click();

            async_delay();

            return new CartPage(driver);
        }


    }
}
