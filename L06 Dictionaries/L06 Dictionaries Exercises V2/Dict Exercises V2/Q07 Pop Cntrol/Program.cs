using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //So many people! It’s hard to count them all. But that’s your job as a statistician.
        //You get raw data for a given city and you need to aggregate it. 

        //On each input line, you’ll be given data in format: "city|country|population".
        //There will be no redundant whitespaces anywhere in the input. 
        //Aggregate the data by country and by city and print it on the console. 
        //For each country, print its total population and on separate lines, the data for each of its cities.
        //Countries should be ordered by their total population in descending order and within each country,
        //the cities should be ordered by the same criterion.
        //If two countries / cities have the same population, keep them in the order in which they were entered.

        var register = new Dictionary<string, Dictionary<string, long>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "report")
            {
                break;
            }

            var inputTokens = input.Split('|').ToArray();

            var country = inputTokens[1];
            var city = inputTokens[0];
            var population = int.Parse(inputTokens[2]);


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
        }

        var mergeDict = new Dictionary<string, long>();

        foreach (var item in register)
        {
            mergeDict[item.Key] = item.Value.Values.Sum();
        }

        foreach (var item in mergeDict.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"{item.Key} (total population: {item.Value})");

            foreach (var index in register[item.Key].OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"=>{index.Key}: {index.Value}");
            }
        }
    }
}