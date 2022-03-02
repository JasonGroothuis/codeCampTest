using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomePageTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            ChromeDriver driver = new();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net";

            ReadOnlyCollection<IWebElement> headerElements = driver.FindElements(By.TagName("h1"));

            IWebElement foundHeader = null;

            foreach (IWebElement headerElement in headerElements )
            {
                if (headerElement.Text == "Web Playground")
                {
                    foundHeader = headerElement;
                    break;
                }
            }

            Assert.IsTrue(foundHeader.Displayed);

            driver.Quit();
        }
    }
}
