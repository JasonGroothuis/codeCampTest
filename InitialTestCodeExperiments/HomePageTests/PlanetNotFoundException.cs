using System;

namespace WebPlaygroundTests
{
    internal partial class PlanetsPage
    {
        public class PlanetNotFoundException : Exception
		{
			public PlanetNotFoundException()
			{
            }
		}
	}
}