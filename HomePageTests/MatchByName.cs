using System;

namespace WebPlaygroundTests.MatchingStrategies
{

	internal class MatchByName : IMatchStrategy
	{
		public Planet planet { get; }

        public bool Match(Planet splanet)
        {
			if (planet == splanet)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool Match(string planetName)
		{
			if (planet.Name == planetName)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
