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
using NUnit.Framework.Internal;
using HomeTask_Epam_2.Pages;

namespace HomeTask_Epam_2
{



    public class BaseTest
    {
        protected IWebDriver driver;
        private readonly string url = "https://rozetka.com.ua/";
        private readonly By mainLogoXpath = By.XPath("//a[@class = 'header__logo']");
        //private readonly By computersCategoryButtonXpath = By.XPath("//a[@class = 'menu-categories__link'][contains(@href, 'computers')]");
        //private readonly By toolsForGamersCategoryButtonXpath = By.XPath("//a[@class = 'menu-categories__link'][contains(@href, 'game')]");
        //private readonly By asusNotebooksButtonXpath = By.XPath("//a[@class = 'portal-brands__item ng-star-inserted'][contains(@href, 'asus')]");
        //private readonly By sortingToolBarXpath = By.XPath("//select[@class = 'select-css ng-untouched ng-pristine ng-valid ng-star-inserted']");
        //private readonly By expensiveSortXpath = By.XPath("//option[contains(@value, 'expensive')]");
        //private readonly By firstElementOnSortedPageXpath = By.XPath("//div[@class = 'goods-tile__inner']");
        //private readonly By addToCartButtonXpath = By.XPath("//app-buy-button[@class = 'toOrder ng-star-inserted']");
        //private readonly By gamersToolsButtonXpath = By.XPath("//span[contains(text(), 'Игровые приставки')]");
        //private readonly By kidsProdsButtonXpath = By.XPath("//a[@class = 'menu-categories__link'][contains(@href, 'kids')]");
        //private readonly By popitProductsXpath = By.XPath("//a[@class = 'portal-brands__item ng-star-inserted'][contains(@href, 'huggies')]");
        //private readonly By cartButtonXpath = By.XPath("//button[@class ='header__button ng-star-inserted header__button--active']");
        //private readonly By cartSumXpath = By.XPath("//div[@class = 'cart-receipt__sum']/div/span");

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public SearchResultPage GetSearchResultPage()
        {
            return new SearchResultPage(GetDriver());
        }

        public HomePage GetHomePage()
        {
            return new HomePage(GetDriver());
        }

        public CartPage GetCartPage()
        {
            return new CartPage(GetDriver());
        }


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}