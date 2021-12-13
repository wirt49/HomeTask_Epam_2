using NUnit.Framework;
using System.Threading;
using HomeTask_Epam_2.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeTask_Epam_2.Tests
{
    
    public class AddToCartTest: BaseTest
    {
        //public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext { get; set; }
        private readonly string searchInput = "laptop asus";
        private readonly int sumToCompare = 10000;
        private bool CompareSum(int firtsSum, int secondSum)
        {
            return firtsSum > secondSum;
        }
        
        
        
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\TestingData.xml",
        //    "Rows", DataAccessMethod.Sequential)]
        //[TestMethod]
        [Test]
        public void CheckCartSum()
        {
            //driver.FindElement(By.XPath("")).SendKeys(TestContext.DataRow)
            HomePage homePage = new HomePage(driver);
            homePage.Search(searchInput);
            SearchResultPage searchResultPage = new SearchResultPage(driver);
            searchResultPage.LoadComplete();
            searchResultPage.ExpensiveSort();
            //searchResultPage.СlickSearchResults();
            Thread.Sleep(1000);
            searchResultPage.AddToCartMostExpensiveProd();
            CartPage cartPage = new CartPage(driver);
            cartPage.OpenCart();
            int cartSum = cartPage.GetCartSum();
            Assert.IsTrue(CompareSum(cartSum, sumToCompare));
        }

    }
}
