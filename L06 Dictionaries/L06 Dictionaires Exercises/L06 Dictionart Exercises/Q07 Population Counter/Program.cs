using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> register = new Dictionary<string, Dictionary<string, long>>();
            // key = Country name, value = Dict of <town, population>
            var input = Console.ReadLine()
                .Split('|')
                .ToArray();

            while (input[0] != "report")
            {
                string city = input[0];
                string country = input[1];
                int population = int.Parse(input[2]);

                bool containsCountry = register.ContainsKey(country);
                if (containsCountry == false)
                {
                    register.Add(country, new Dictionary<string, long>());
                    register[country].Add(city, population);
                }

                else
                {
                    register[country].Add(city, population);
                }

                input = Console.ReadLine()
                    .Split('|')
                    .ToArray();
            }

            var mergeDict = new Dictionary<string, long>();

            foreach (var countryTown in register)
            {
                mergeDict[countryTown.Key] = countryTown.Value.Values.Sum();
            }

            foreach (var country in mergeDict.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})"); // Country: total population

                foreach (var town in register[country.Key].OrderByDescending(x => x.Value)) // orders the towns pop
                {
                    Console.WriteLine($"=>{town.Key}: {town.Value}"); // town: town population
                }
            }

        }
    }
}
