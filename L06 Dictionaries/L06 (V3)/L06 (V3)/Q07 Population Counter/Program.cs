using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instuctions:
        // So many people! It’s hard to count them all. But that’s your job as a statistician.You get raw data for a given city and you need to aggregate it.
        // On each input line, you’ll be given data in format: "city|country|population".There will be no redundant whitespaces anywhere in the input.Aggregate the data by country and by city and print it on the console.
        // For each country, print its total population and on separate lines, the data for each of its cities.Countries should be ordered by their total population in descending order and within each country, the cities should be ordered by the same criterion.
        // If two countries / cities have the same population, keep them in the order in which they were entered.Check out the examples; follow the output format strictly!

        // Input
        // •	The input data should be read from the console.
        // •	It consists of a variable number of lines and ends when the command "report" is received.
        // •	The input data will always be valid and in the format described.There is no need to check it explicitly.

        // Output
        // •	The output should be printed on the console.
        // •	Print the aggregated data for each country and city in the format shown below.

        // Constraints
        // •	The name of the city, country and the population count will be separated from each other by a pipe('|').
        // •	The number of input lines will be in the range[2 … 50].
        // •	A city - country pair will not be repeated.
        // •	The population count of each city will be an integer in the range[0 … 2 000 000 000].
        // •	Allowed working time for your program: 0.1 seconds.Allowed memory: 16 MB.

        // Example: 
        //          Input	                                   Output
        // Sofia | Bulgaria | 1000000              Bulgaria(total population: 1000000)
        // report                                        =>Sofia: 1000000
        #endregion

        // Initialize nested dict: key = (string)country, value = (Dict<(string)key = town, (int)value = population>)
        var record = new Dictionary<string, Dictionary<string, int>>();

        // Recieve input and update dict
        string input = Console.ReadLine();
        while (input != "report")
        {
            // Getting data
            var elements = input.Split('|').ToArray();

            string city = elements[0];
            string country = elements[1];
            int population = int.Parse(elements[2]);

            // if new country
            bool newCountry = !record.ContainsKey(country);
            if (newCountry)
            {
                record[country] = new Dictionary<string, int>();
            }

            record[country][city] = population;

            input = Console.ReadLine();
        }

        // Sort and print
        var ordered = record.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        foreach (var country in ordered)
        {
            int population = country.Value.Values.Sum();
            Console.WriteLine($"{country.Key} (total population: {population})");
            foreach (var city in country.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"=>{city.Key}: {city.Value}");
            }
        }
    }
}