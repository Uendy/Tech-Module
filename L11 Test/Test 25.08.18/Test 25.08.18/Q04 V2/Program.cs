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
                    currentTown.Passangers -= passangers;
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
                townArrived.Passangers = 0;
                townArrived.Time = 0;
            }
            else // find old town and update
            {
                townArrived = towns.Find(x => x.Name == townName);
            }

            //TODO: UPDATE
            //townAndPassangers[townName] += passangers;
            //bool fasterTime = townAndTime[townName] >= 0 && townAndTime[townName] > time;
            //if (fasterTime)
            //{
            //    townAndPassangers[townName] = time;
            //}

            input = Console.ReadLine();
        }

        //Order and Print
    }
}