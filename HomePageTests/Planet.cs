using OpenQA.Selenium;

namespace WebPlaygroundTests
{
    internal class Planet
    {
        //public IWebDriver driver;
        //public IWebElement planet;
        IWebElement thisElement;
        public string Name => thisElement.FindElement(By.ClassName("planet")).Text;

        public Planet(IWebElement planet)
        {
            this.thisElement = planet;     
        }
    }
}

/// Predicate<string> isUpper = delegate(string s) { return s.Equals(s.ToUpper());};