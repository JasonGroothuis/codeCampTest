using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace WebPlaygroundTests
{
    internal partial class PlanetsPage : WebPage
	{
		private IWebElement popupmessage => driver.FindElement(By.ClassName("popup-message"));
		private IWebElement exploreEarthButton;
		private IEnumerable<Planet> planets;
		Planet planet;

		public PlanetsPage(IWebDriver driver, string url)
		{
			this.driver = driver;
			this.driver.Url = url;
		}

		internal IEnumerable<Planet> GetPlanets()
        {
			var allPlanets = driver.FindElements(By.ClassName("planet"));
			List<Planet> result = new();
			foreach (var planet in allPlanets)
			{
				//yield return new Planet(planet);
				result.Add(new Planet(planet));
            }
			return result;
        }

		internal Planet GetPlanet(Predicate<Planet> matchStratgey)
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
		/*internal Planet GetPlanet(Predicate<string> matchStratgey)
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
		internal string ClickExploreEarthAwaitPopup()
        {
			planets = GetPlanets();
			planet = GetPlanet(p => p.Name == "Earth");
			//Console.WriteLine("Found planet Element is " + planet.Name);

			//planet
			/*
			ReadOnlyCollection<IWebElement> planets = driver.FindElements(By.Id("planet")); // or maybe by classname ?
			IWebElement exploreEarthButton;

			foreach (IWebElement planet in planets)  // Can Model Planet as own class, feeding the page Element 'planet;
            {	
				IWebElement hdr = planet.FindElement(By.TagName("h2")); // maybe name ...
				if (hdr.Text == "Earth") break;
            }

			///ThisElement.FindElement...
			/// 

			/// Change to return a "Planet" ... make a GetPlanets() return ReadOnly Collect
			/// ...yield return
			/// 
			*/

			return "exploring...";
        }
	}
}