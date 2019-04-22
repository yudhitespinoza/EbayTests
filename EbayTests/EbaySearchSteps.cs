using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace EbayTests
{
    [Binding]
    public class EbaySearchSteps
    {
        private IWebDriver driver;
        private EbaySearchPage searchPage;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            searchPage = new EbaySearchPage(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
                driver.Quit();
        }

        [Given(@"I have opened the ebay page")]
        public void GivenIHaveOpenedTheEbayPage()
        {
            searchPage.GoToEbayPage();
            searchPage.SetEnglishLanguage();                       
        }
        
        [When(@"I type the '(.*)' search text")]
        public void WhenITypeTheSearchText(string searchText)
        {
            searchPage.EnterSearchText(searchText);
        }

        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            searchPage.ClickSearchButton();
        }

        [When(@"I sort products by '(.*)' order")]
        public void WhenISortProductsByOrder(string sorting)
        {
            searchPage.HoverOverSortingDropDown();
            searchPage.SelectSorting(sorting);  
        }

        [When(@"I select the '(.*)' condition")]
        public void WhenISelectTheCondition(string condition)
        {
            searchPage.HoverOverConditionDropDown();
            searchPage.SelectCondition(condition);
        }        

        [Then(@"The products are displayed in the correct order")]
        public void ThenTheProductsAreDisplayedInTheCorrectOrder(Table table)
        {
            Console.WriteLine("Number of Results: " + searchPage.GetNumberOfResults());

            var products = searchPage.GetProducts();
            var expectedProducts = table.Rows;

            Assert.IsTrue(products.Count >= 5);

            for (int i = 0; i < 5; i++)
            {                
                Console.WriteLine("Product Name: " + products[i].Name);
                Console.WriteLine("Product Price : " + products[i].Price );
                Console.WriteLine("Shipping Cost : " + products[i].ShippingCost);

                Assert.AreEqual(expectedProducts[i][0], products[i].Name);
            }           
        }       
    }
}
