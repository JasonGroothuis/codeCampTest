using System;

namespace WebPlaygroundTests.MatchingStrategies
{ 
	internal interface IMatchStrategy
	{
		//public bool Match(Planet planet);
		public bool Match(string planetName);
    }
}
