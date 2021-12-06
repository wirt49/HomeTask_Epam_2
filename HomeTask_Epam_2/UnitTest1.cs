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

namespace HomeTask_Epam_2
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly string url = "https://rozetka.com.ua/";
        private readonly By mainLogoXpath = By.XPath("//a[@class = 'header__logo']");
        private readonly By computersCategoryButtonXpath = By.XPath("//a[@class = 'menu-categories__link'][contains(@href, 'computers')]");
        private readonly By toolsForGamersCategoryButtonXpath = By.XPath("//a[@class = 'menu-categories__link'][contains(@href, 'game')]");
        private readonly By asusNotebooksButtonXpath = By.XPath("//a[@class = 'portal-brands__item ng-star-inserted'][contains(@href, 'asus')]");
        private readonly By sortingToolBarXpath = By.XPath("//select[@class = 'select-css ng-untouched ng-pristine ng-valid ng-star-inserted']");
        private readonly By expensiveSortXpath = By.XPath("//option[contains(@value, 'expensive')]");
        private readonly By firstElementOnSortedPageXpath = By.XPath("//div[@class = 'goods-tile__inner']");
        private readonly By addToCartButtonXpath = By.XPath("//app-buy-button[@class = 'toOrder ng-star-inserted']");
        private readonly By gamersToolsButtonXpath = By.XPath("//span[contains(text(), 'Игровые приставки')]");
        private readonly By kidsProdsButtonXpath = By.XPath("//a[@class = 'menu-categories__link'][contains(@href, 'kids')]");
        private readonly By popitProductsXpath = By.XPath("//a[@class = 'portal-brands__item ng-star-inserted'][contains(@href, 'huggies')]");
        private readonly By cartButtonXpath = By.XPath("//button[@class ='header__button ng-star-inserted header__button--active']");
        private readonly By cartSumXpath = By.XPath("//div[@class = 'cart-receipt__sum']/div/span");
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            
        }

        [Test]
        public void Test1()
        {
            var computersCategoryButton = driver.FindElement(computersCategoryButtonXpath);
            computersCategoryButton.Click();
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            var asusNotebooksButton = driver.FindElement(asusNotebooksButtonXpath);
            asusNotebooksButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //var sortingToolBar = driver.FindElement(sortingToolBarXpath);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //sortingToolBar.Click();
            //sortingToolBar.SendKeys(Keys.ArrowDown + Keys.ArrowDown);
            //sortingToolBar.SendKeys(Keys.Enter);

            var expensiveSort = driver.FindElement(expensiveSortXpath);
            expensiveSort.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var firstElementOnSortedPage = driver.FindElement(firstElementOnSortedPageXpath);
            //bool isFirstVisible = firstElementOnSortedPage.Displayed;
            //firstElementOnSortedPage.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var addToCartButton = driver.FindElement(addToCartButtonXpath);
            addToCartButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var mainLogo = driver.FindElement(mainLogoXpath);
            mainLogo.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var gameCategoryButton = driver.FindElement(toolsForGamersCategoryButtonXpath);
            gameCategoryButton.Click();

            var gamersToolsButton = driver.FindElement(gamersToolsButtonXpath);
            gamersToolsButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var expensiveSortSecondPage = driver.FindElement(expensiveSortXpath);
            expensiveSortSecondPage.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var addToCartOnSecondPage = driver.FindElement(addToCartButtonXpath);
            addToCartOnSecondPage.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var mainLogo2 = driver.FindElement(mainLogoXpath);
            mainLogo2.Click();
            mainLogo2.SendKeys(Keys.Home);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var kidsProdsButton = driver.FindElement(kidsProdsButtonXpath);
            kidsProdsButton.Click();
            var popitProdButton = driver.FindElement(popitProductsXpath);
            popitProdButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var expensiveSortThirdPage = driver.FindElement(expensiveSortXpath);
            expensiveSortThirdPage.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var addToCartOnThirdPage = driver.FindElement(addToCartButtonXpath);
            addToCartOnThirdPage.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var cartButton = driver.FindElement(cartButtonXpath);
            cartButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var sum = driver.FindElement(cartSumXpath).Text;
            int value;
            int.TryParse(string.Join("", sum.Where(c => char.IsDigit(c))), out value);
            bool compareSum = value > 5000;
            Assert.IsTrue(compareSum);

            

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}