using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPlayground_Tests.Models
{
    public class Planets : IEnumerable<string>
    {
        public List<string> names;

        public Planets()
        {
            names = new List<string>();
        }
        public Planets(string planetName)
        {
            names = new List<string>();
            names.Add(planetName);
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach(string planetName in names)
            {
                yield return planetName;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
