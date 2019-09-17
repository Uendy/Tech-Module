using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var towns = new List<Town>();

        string input = Console.ReadLine();
        while (input != "Slide rule")
        {
            var inputTokens = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string townName = inputTokens[0];

            var otherInfo = inputTokens[1].Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            int passangers = int.Parse(otherInfo[1]);
            string command = otherInfo[0];
            if (command == "ambush")
            {
                bool townExists = towns.Any(x => x.Name == townName);
                if (townExists)
                {
                    var currentTown = towns.Find(x => x.Name == townName);
                    currentTown.Time = 0;
                    currentTown.Passengers -= passangers;
                }

                input = Console.ReadLine();
                continue;
            }

            int time = int.Parse(otherInfo[0]);

            var townArrived = new Town();

            bool newTown = !towns.Any(x => x.Name == townName);
            if (newTown)
            {
                townArrived.Name = townName;
                townArrived.Passengers = 0;
                townArrived.Time = 0;
            }
            else // find old town and update
            {
                townArrived = towns.Find(x => x.Name == townName);
            }

            bool fasterTime = townArrived.Time <= 0 || townArrived.Time > time;
            if (fasterTime)
            {
                townArrived.Time = time;
            }

            townArrived.Passengers += passangers;

            if (newTown)
            {
                towns.Add(townArrived);
            }
            input = Console.ReadLine();
        }

        //Order and Print
        var result = towns.Where(x => x.Time != 0).OrderBy(x => x.Time).ThenBy(x => x.Name).ToList();

        foreach (var town in result)
        {
            Console.WriteLine($"{town.Name} -> Time: {town.Time} -> Passengers: {town.Passengers}");
        }
    }
}