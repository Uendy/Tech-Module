using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //Create a program that lists the results from the International SoftUniada Competition. You will be receiving input lines in the following format:
        // “{ countryName} -> { contestantName} -> { contestantPoints}”

        //You must calculate the total points of each country, which are the total points of the contestants from this country.
        //Every contestant can take part in more than one contest in the SoftUniada and you must keep his total points from the SoftUniada competition.
        //Each of the contestants are allowed to compete for only one country.
        //You will be receiving the strings with that information until the “END” command is given.

        //In the end, print the countries with their points and their contestants with their points, ordered by the total points for the countries in descending order, 
        //in the following format:

        //{ country}: { totalPointsForCountry}
        //-- { contestantName} -> { contestantTotalPoints}
        //-- { contestantName} -> { contestantTotalPoints}
        //{ country}: { totalPointsForCountry}
        //-- { contestantName} -> { contestantTotalPoints}
        //-- { contestantName} -> { contestantTotalPoints}
        #endregion

        var countries = new List<Country>();
        var participants = new List<string>(); //Each of the contestants are allowed to compete for only one country.

        string input = Console.ReadLine();
        while (input != "END")
        {
            var inputTokens = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string country = inputTokens[0];
            string participant = inputTokens[1];
            long points = int.Parse(inputTokens[2]);

            var currentCountry = new Country();

            bool newCountry = !countries.Any(x => x.Name == country);
            if (newCountry) // make the new country
            {
                currentCountry.Name = country;
                currentCountry.CoderAndPoints = new Dictionary<string, long>();
                currentCountry.TotalPoints = 0;

                countries.Add(currentCountry); // see if this will due the reference type thing, or after the calculations I need to keep adding it to the list
            }
            else
            {
                currentCountry = countries.Find(x => x.Name == country);
            }

            bool inAnyTeam = participants.Contains(participant); // check if he is in any team
            if (!inAnyTeam) // not in any team so make him into your team
            {
                currentCountry.CoderAndPoints[participant] = 0;
                participants.Add(participant);
            }

            bool inYourTeam = currentCountry.CoderAndPoints.ContainsKey(participant); // already in your team so add to his points
            if (inYourTeam) // add him to your team
            {
                currentCountry.CoderAndPoints[participant] += points;
                currentCountry.TotalPoints += points;
            }

            bool cheater = !inYourTeam && currentCountry.CoderAndPoints.Keys.Count() == 0; //you have added this country but it cheated by using another countries coder.
            if (cheater)                                                                  // if It has no coders we delete it
            {
                countries.Remove(currentCountry);
            }

            input = Console.ReadLine();
        }

        //order by total points in descending order
        var rankings = countries.OrderByDescending(x => x.TotalPoints).ToList();
        foreach (var country in rankings)
        {
            Console.WriteLine($"{country.Name}: {country.TotalPoints}");
            foreach (var coder in country.CoderAndPoints)
            {
                Console.WriteLine($"-- {coder.Key} -> {coder.Value}"); // key = name, value = points
            }
        }
    }
}