using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebPlayground_Tests.models;

namespace WebPlayground_Tests {
    [TestClass]
    public class FormPageTests
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
        public void TestModernFormSubmit()
        {
            const string name = "JasonG";
            const string email = "JasonG@gmail.com";
            const string state = "SA";
            string expectedPopupMessage = $"Thanks for your feedback {name}";
            // Arrange
            FormPage formPage = new(driver, "https://d18u5zoaatmpxx.cloudfront.net/#/forms");
            // Act
            formPage.SubmitModernFormData(name, email, state);
            // Assert
            Assert.AreEqual(expected: expectedPopupMessage, actual: formPage.ClickSubmitAwaitPopup());
        }
        

    }
}
