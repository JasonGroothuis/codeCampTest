using OpenQA.Selenium;

namespace WebPlaygroundTests
{
    internal class WebPage
    {
        protected
            OpenQA.Selenium.IWebDriver driver;
        public WebPage()
        {
        }
        public WebPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public WebPage(IWebDriver driver, string url)
        {
            this.driver = driver;
            this.driver.Url = url;
        }
    }
}