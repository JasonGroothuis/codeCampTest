using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace FormPageTests
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


    }
}