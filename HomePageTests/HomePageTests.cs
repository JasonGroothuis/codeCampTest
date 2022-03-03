using System;
using System.Collections.ObjectModel;
//using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HomePageTests
{
    [TestClass]
    public class HomePageTests
    {
        private const string expectedPopupMessage = "Hello JasonG";
        private IWebDriver driver;
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net";
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestHeader1()
        {
            /* 
             * Simplify to New Homepage (driver), Assert Header GetHeaderCalled "Web Playground"
             */
            //driver.Url = "https://d18u5zoaatmpxx.cloudfront.net";

            ReadOnlyCollection<IWebElement> headerElements = driver.FindElements(By.TagName("h1"));

            IWebElement foundHeader = null;

            foreach (IWebElement headerElement in headerElements)
            {
                if (headerElement.Text == "Web Playground")
                {
                    foundHeader = headerElement;
                    break;
                }
            }

            Assert.IsTrue(foundHeader.Displayed);
        }

        [TestMethod]
        public void TestHeader2()
        {
            HomePage homePage = new(driver);
            Assert.IsTrue(homePage.getHeaderCalled("Web Playground"));
        }

        [TestMethod]
/*
 * Arrange - new Homepage, Act, Set Forename and Click Submit, Assert: wait until popup displayed popupname.text, 
 * Further simplification: New Homepage, SubmitForename & driver wait  d=> homePage.IsPopupElementDisplayed(), 
 */
        public void TestNameSubmit()
        {
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net";

            IWebElement foundForenameEdit = driver.FindElement(By.Id("forename"));
            foundForenameEdit.SendKeys("JasonG");
            IWebElement foundSubmitBtn = driver.FindElement(By.Id("submit"));
            foundSubmitBtn.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            IWebElement popupElement = driver.FindElement(By.ClassName("popup-message"));
            wait.Until(d => popupElement.Displayed);

            string actualResult = popupElement.Text;
            Assert.AreEqual(expected: expectedPopupMessage, actual: actualResult);
        }

    }
}
