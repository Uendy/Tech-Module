using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //As a thinker you are always given new tasks.This time you are working for Mr.Harry King. 
        //You have to take part in the new railway system and keep track on how things are going there.

        //You will receive input lines in one of the following formats:

        //{ townName}:{ time}->{ passengersCount}
        //If you receive the line above, Iron Girder has travelled to certain town for a certain amount of time with certain count of passengers.
        //You need to keep track for each town. You have to save the fastest time Iron Girder reaches a town and the total count of passengers for each town.

        //{ townName}:ambush->{ passengersCount}
        //If you receive the line above, somewhere along the track to the current town Iron Girder was ambushed and the passengers can't reach there. 
        //If this happens you need to set the time record for this town to "0" and remove the current count of passengers from the total count. 
        //If it's the first time Iron Girder travels to this town then you simply ignore this line.

        //When you receive "Slide rule" you end the program and print data for each town in the following format:
        //"{townName} -> Time: {fastestTime} -> Passengers: {totalCountPassengers}"
        //The output should be ordered by best time and then by town's name. 
        //If a town is with no recorded time (the time is equal to 0) or there are no passengers (count is equal or less than 0) you should not print it.

        var townAndTime = new Dictionary<string, int>();          //Key = townName (string), Value = bestTime (int)
        var townAndPassangers = new Dictionary<string, long>();   //Key = townName (string), value = totalPassangers (long)

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
                bool townExists = townAndPassangers.ContainsKey(townName);
                if (townExists)
                {
                    townAndTime[townName] = 0;
                    townAndPassangers[townName] -= passangers;
                }

                input = Console.ReadLine();
                continue;
            }

            int time = int.Parse(otherInfo[0]);

            bool newTown = !townAndPassangers.ContainsKey(townName);
            if (newTown)
            {
                townAndPassangers[townName] = 0;
                townAndTime[townName] = 0;
            }

            townAndPassangers[townName] += passangers;
            bool fasterTime = townAndTime[townName] >= 0 && townAndTime[townName] > time;
            if (fasterTime)
            {
                townAndPassangers[townName] = time;
            }

            input = Console.ReadLine();
        }

        //Order and print
        var resultTime = townAndTime.Where(x => x.Value != 0).OrderBy(x => x.Value); // cant order by from 2 different dicts, so do it with a Class Town
    }
}