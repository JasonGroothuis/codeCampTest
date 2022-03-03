using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace HomePageTests
{
	internal class HomePage
	{
		IWebDriver driver;
		IWebElement popupmessage;
		IWebElement SubmitButton;
		public HomePage(IWebDriver driver)
		{
			this.driver = driver;
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
        public string ClickSubmitAwaitPopup()
        {
            SubmitButton = driver.FindElement(By.Id("submit"));
            SubmitButton.Click();
            popupmessage = driver.FindElement(By.ClassName("popup-message"));
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(d => popupmessage.Displayed);
            return popupmessage.Text;
        }

        internal void SendForenameKeys(string name)
        {
            IWebElement foundForenameEdit = driver.FindElement(By.Id("forename"));
            foundForenameEdit.SendKeys(name);
        }
    }
}