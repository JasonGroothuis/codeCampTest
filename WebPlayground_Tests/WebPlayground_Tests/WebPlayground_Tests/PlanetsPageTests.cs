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
        internal  PlanetsPage planetsPage;
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            planetsPage = new(driver, "https://d18u5zoaatmpxx.cloudfront.net/#/planets");
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestPlanetsPageHeader()
        {
            Assert.IsTrue(planetsPage.getHeaderCalled("Planets"));
        }

        [TestMethod]
        public void TestPlanetsPagePlanetsClassElementExists()
        {
            Assert.IsTrue(planetsPage.Planets.GetAttribute("class") == "planets");
        }

        [TestMethod]
        public void TestPlanetsPagePlanetEarthCardExists()
        {
            Assert.IsTrue(planetsPage.GetPlanetsNames()[2] == "Earth");
        }
    }
}