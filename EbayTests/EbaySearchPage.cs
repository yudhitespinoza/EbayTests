using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace EbayTests
{
    public class EbaySearchPage
    {
        private IWebDriver _driver;

        public EbaySearchPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        private readonly string ebayUrl = "https://www.ebay.com/";

        private IWebElement DefaultLanguage => _driver.FindElement(By.Id("gh-eb-Geo-a-default"));
        private IWebElement EnglishLanguage => _driver.FindElement(By.Id("gh-eb-Geo-a-en"));

        private IWebElement SearchTextBox => _driver.FindElement(By.Id("gh-ac"));
        private IWebElement SearchButton => _driver.FindElement(By.Id("gh-btn"));

        private IWebElement SortingFlyOut => _driver.FindElement(By.Id("w4-w3"));
        private IWebElement SortingDropDown => SortingFlyOut.FindElement(By.TagName("button"));
        private IWebElement SortingMenu => _driver.FindElement(By.ClassName("srp-sort__menu"));

        private IWebElement ConditionFlyOut => _driver.FindElement(By.Id("w4-w1"));
        private IWebElement ConditionDropDown => ConditionFlyOut.FindElement(By.TagName("button"));
        private IWebElement ConditionMenu => _driver.FindElement(By.ClassName("srp-controls__list"));
        
        private IWebElement NumberOfResults => _driver.FindElement(By.ClassName("srp-controls__count-heading"));

        private ReadOnlyCollection<IWebElement> ProductCards => _driver.FindElements(By.ClassName("s-item"));

        public void GoToEbayPage()
        {
            _driver.Navigate().GoToUrl(ebayUrl);
        }

        public void SetEnglishLanguage()
        {
            DefaultLanguage.Click();
            EnglishLanguage.Click();
        }

        public void EnterSearchText(string searchText)
        {
            SearchTextBox.SendKeys(searchText);
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        public void HoverOverSortingDropDown()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(SortingDropDown).Perform();
        }

        public void SelectSorting(string sorting)
        {
            var sortingMenuOption = SortingMenu.FindElement(By.XPath($".//span[text()='{sorting}']"));
            sortingMenuOption.Click();
        }

        public void HoverOverConditionDropDown()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(ConditionDropDown).Perform();
        }

        public void SelectCondition(string condition)
        {            
            var conditionMenuOption = ConditionMenu.FindElement(By.XPath($".//a[text()='{condition}']"));
            conditionMenuOption.Click();
        }

        public string GetNumberOfResults()
        {
            return NumberOfResults.Text;
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            foreach (var productCard in ProductCards)
            {                
                var productName = productCard.FindElement(By.XPath(".//h3[@class='s-item__title']")).Text;
                var productPrice = productCard.FindElement(By.XPath(".//span[@class='s-item__price']")).Text;
                var shippingCost = productCard.FindElement(By.XPath(".//span[contains(@class,'s-item__shipping')]")).Text;

                products.Add(new Product
                {
                    Name = productName,
                    Price = productPrice,
                    ShippingCost = shippingCost
                });
            }

            return products;
        }
    }
}
