using System.Collections.ObjectModel;
using System.Threading;
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

            var driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net";

            ReadOnlyCollection<IWebElement>? headerElements = driver.FindElements(By.TagName("h1"));

            IWebElement foundHeader = null;

            foreach (var headerElement in headerElements )
            {
                if (headerElement.Text == "Web Playground")
                {
                    foundHeader = headerElement;
                    break;
                }
            }

            Thread.Sleep(1000);
            Assert.IsTrue(foundHeader.Displayed);

            driver.Quit();
        }
    }
}
