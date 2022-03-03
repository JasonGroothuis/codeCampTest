using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace FormPageTests
{
    internal class FormPage
    {
        IWebDriver driver;
        IWebElement popupmessage;
        IWebElement SubmitButton;
        public FormPage(IWebDriver driver)
        {
            this.driver = driver;
        }


    }
}