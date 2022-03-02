using System;
using System.Collections.ObjectModel;
using System.Threading;
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
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestHeader()
        {
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net";

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
