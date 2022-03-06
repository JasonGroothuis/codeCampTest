using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WebPlayground_Tests.models.basemodel;
using WebPlayground_Tests.Models;

namespace WebPlayground_Tests.models
{
    internal class PlanetsPage : WebPage
    {
        private IWebElement popupmessage;
        private IWebElement ExploreEarthButton;
        public IWebElement Planets => driver.FindElement(By.ClassName("planets"));
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

        internal List<string> GetPlanetsNames()
        {
            ReadOnlyCollection<IWebElement> planetElements = driver.FindElements(By.ClassName("planet"));
            List<string> result = new();
            foreach (IWebElement planetElement in planetElements)
            {
                string newPlanetName = new(planetElement.FindElement(By.TagName("h2")).Text);

                result.Add(newPlanetName);
                Console.WriteLine(newPlanetName + " Added");
            }
            return result;
        }

 /*       internal Planet GetPlanet(Predicate<Planet> matchStratgey)
        {
            foreach (var planet in GetPlanets())
            {
                if (matchStratgey.Invoke(planet))
                {
                    return planet;
                }
            }
            throw new PlanetNotFoundException();
        }
 */

    }
}