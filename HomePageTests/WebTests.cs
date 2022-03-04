using System;
using System.Collections.ObjectModel;
using System.Threading;
//using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebPlaygroundTests
{
    [TestClass]
    public class WebTests
    {
        private const string Name = "JasonG";
        private const string expectedPopupMessage = "Hello " + Name;
        private const string expectedExploreEarthPopupMessage = "Exploring Earth";
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
            HomePage homePage = new(driver, "https://d18u5zoaatmpxx.cloudfront.net/#/");
            Assert.IsTrue(homePage.getHeaderCalled("Web Playground"));
        }

        [TestMethod]
        public void TestNameSubmit()
        {
            HomePage homePage = new(driver, "https://d18u5zoaatmpxx.cloudfront.net/#/");
            homePage.SendForenameKeys(Name);
            Assert.AreEqual(expected: expectedPopupMessage, actual: homePage.ClickSubmitAwaitPopup() );
        }
        [TestMethod]
        public void TestModernFormSubmit()
        {
            // Arrange
            FormPage formPage = new(driver, "https://d18u5zoaatmpxx.cloudfront.net/#/forms");
            // Act
            formPage.SubmitModernFormData(name: "JasonG", email: "jasong@gmail.com", state: "SA");
            //Assert
            Assert.AreEqual(expected: expectedPopupMessage, actual: formPage.ClickSubmitAwaitPopup());

        }

        [TestMethod]
        public void TestPlanetsExploreEarth()
        {

            PlanetsPage planetsPage = new(driver, "https://d18u5zoaatmpxx.cloudfront.net/#/planets");
            Assert.AreEqual(expected: expectedExploreEarthPopupMessage,
                            actual: planetsPage.ClickExploreEarthAwaitPopup());
        }

    }
}
