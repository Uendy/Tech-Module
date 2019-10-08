using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        //You have to make a weather forecast about the weather depending on strings, which you receive from the console. 
        //Every string consists of data about the city, average temperature and weather type. You will receive strings until you receive the command “end”. 

        //Every valid weather forecast consists of:
        //•	Two Latin capital letters, which represent the code of the city
        //•	Immediately followed by a floating - point number, which will represent the average temperature. Numbers without a floating point are not considered valid.
        //•	Followed by the type of weather, which will consist of uppercase and lowercase Latin letters, starts immediately after the temperature and ends at the first occurrence of the sign ‘|’

        //If you receive input, which does not follow the rules above – ignore it.
        //If you receive a new temperature and / or type of weather for a city, which already exists – rewrite the previous values.
        //At the end, print the temperature and weather type for every city. Order the cities by average temperature in ascending order.

        var towns = new List<Town>();

        string pattern = @"[A-Z]{2}\d+\.\d+[A-Za-z]+\|";
        var regex = new Regex(pattern);

        string decimalPattern = @"\d+\.\d+";
        var decimalRegex = new Regex(decimalPattern);


        string input = Console.ReadLine();
        while (input != "end")
        {
            bool isMatch = regex.IsMatch(input);
            if (isMatch)
            {
                string town = new string(input.Take(2).ToArray()); // town name

                var decimalFound = decimalRegex.Match(input).Value; // getting the weather temp from the input using the decimalRegex
                var tempreture = Math.Round(double.Parse(decimalFound),2);

                //get rid of the town and decimal part, then split from the unconsequential ending part and take the [0] part
                var remainingParts = input.Replace(town, "").Replace(decimalFound, "").Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string forecast = remainingParts[0];

                bool newTown = !towns.Any(x => x.Name == town);
                if (newTown)
                {
                    var currentTown = new Town()
                    {
                        Name = town,
                        Tempreture = tempreture,
                        Forecast = forecast
                    };

                    towns.Add(currentTown);
                }
                else // find and update existing town
                {
                    var currentTown = towns.Find(x => x.Name == town);
                    currentTown.Tempreture = tempreture;
                    currentTown.Forecast = forecast;
                }
            }
            input = Console.ReadLine();
        }

        var result = towns.OrderBy(x => x.Tempreture).ToList();
        foreach (var town in result)
        {
            Console.WriteLine($"{town.Name} => {town.Tempreture} => {town.Forecast}");
        }
    }
}