using OpenQA.Selenium;
using System;

namespace WebPlayground_Tests.models
{
    internal class FormPage : basemodel.WebPage
    {
        IWebElement popupmessage;
        IWebElement SubmitButton;
        IWebElement agreeCheckBox;

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
        private void SendAgreeClick()
        {
            agreeCheckBox = driver.FindElement(By.CssSelector("label[for=agree]"));
            agreeCheckBox.Click();
        }
        public string ClickSubmitAwaitPopup()
        {
            SubmitButton = driver.FindElement(By.CssSelector("#app > div.v-application--wrap > main > div > div > div.layout.justify-center.wrap > div > div > div.v-window.v-item-group.theme--light.v-tabs-items > div > div > div > div > form > button:nth-child(5) > span"));
            SubmitButton.Click();
            popupmessage = driver.FindElement(By.ClassName("popup-message"));
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => popupmessage.Displayed);
            return popupmessage.Text;
        }
        internal void SubmitModernFormData(string name, string email, string state)
        {
            SendNameKeys(name);
            SendEmailKeys(email);
            SendStateKeys(state);
            SendAgreeClick();
            ClickSubmitAwaitPopup();
        }
    }
}