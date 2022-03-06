using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebPlayground_Tests.models;

namespace WebPlayground_Tests
{
    [TestClass]
    public class HomePageTests
    {
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
        public void TestHomePageHeader()
        {
            HomePage homePage = new(driver, "https://d18u5zoaatmpxx.cloudfront.net/#/");
            Assert.IsTrue(homePage.getHeaderCalled("Web Playground"));
        }

        [TestMethod]
        public void TestHomePageNameSubmit()
        {
            const string Name = "JasonG";
            string expectedPopupMessage = $"Hello {Name}";
            HomePage homePage = new(driver, "https://d18u5zoaatmpxx.cloudfront.net/#/");
            homePage.SendForenameKeys(Name);
            Assert.AreEqual(expected: expectedPopupMessage, actual: homePage.ClickSubmitAwaitPopup());
        }
    }
}
