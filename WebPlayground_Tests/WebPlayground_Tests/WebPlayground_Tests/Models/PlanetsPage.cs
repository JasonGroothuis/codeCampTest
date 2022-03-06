using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using WebPlayground_Tests.models.basemodel;

namespace WebPlayground_Tests.models
{
    internal class PlanetsPage : WebPage
    {
        IWebElement popupmessage;
        IWebElement ExploreEarthButton;
        public PlanetsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public PlanetsPage(IWebDriver driver, string url)
        {
            this.driver = driver;
            this.driver.Url = url;
        }

        internal bool getHeaderCalled(string v)
        {
            ReadOnlyCollection<IWebElement> headerElements = driver.FindElements(By.TagName("h1"));

            IWebElement foundHeader = null;

            foreach (IWebElement headerElement in headerElements)
            {
                if (headerElement.Text == v)
                {
                    foundHeader = headerElement;
                    return true;
                }
            }

            return false;
        }
    }
}