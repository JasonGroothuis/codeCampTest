using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebPlayground_Tests.models;

namespace WebPlayground_Tests
{
    [TestClass]
    public class PlanetsPageTests
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
        public void TestPlanetsPageHeader()
        {
            PlanetsPage planetsPage = new(driver, "https://d18u5zoaatmpxx.cloudfront.net/#/planets");
            Assert.IsTrue(planetsPage.getHeaderCalled("Planets"));
        }
    }
}