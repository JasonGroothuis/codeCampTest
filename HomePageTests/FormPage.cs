using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace WebPlaygroundTests
{
    internal class FormPage  : WebPage
    {

        public FormPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public FormPage(IWebDriver driver, string url)
        {
            this.driver = driver;
            this.driver.Url = url;
        }
        internal void SendNameKeys(string name)
        {
            IWebElement foundNameEdit = driver.FindElement(By.Id("name"));
            foundNameEdit.SendKeys(name);
        }
        internal void SendEmailKeys(string email)
        {
            IWebElement foundEmailEdit = driver.FindElement(By.Id("email"));
            foundEmailEdit.SendKeys(email);
        }
        internal void SendStateKeys(string state)
        {
            IWebElement foundStateEdit = driver.FindElement(By.Id("state"));
            foundStateEdit.SendKeys(state);
        }
        internal void SubmitModernFormData(string name, string email, string state)
        {
            SendNameKeys(name);
            SendEmailKeys(email);
            SendStateKeys(state);
        }

    }
}