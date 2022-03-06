using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using WebPlayground_Tests.models.basemodel;

namespace WebPlayground_Tests.models
{
    internal class HomePage : WebPage
    {
        IWebElement popupmessage;
        IWebElement SubmitButton;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public HomePage(IWebDriver driver, string url)
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
                if (headerElement.Text == "Web Playground")
                {
                    foundHeader = headerElement;
                    return true;
                }
            }

            return false;
        }
        internal void SendForenameKeys(string name)
        {
            IWebElement foundForenameEdit = driver.FindElement(By.Id("forename"));
            foundForenameEdit.SendKeys(name);
        }

        internal string ClickSubmitAwaitPopup()
        {
            SubmitButton = driver.FindElement(By.Id("submit"));
            SubmitButton.Click();
            popupmessage = driver.FindElement(By.ClassName("popup-message"));
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(d => popupmessage.Displayed);
            return popupmessage.Text;
        }
    }
}