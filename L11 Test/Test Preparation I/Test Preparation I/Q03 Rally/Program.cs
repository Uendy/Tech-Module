using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //You are given the names of the participants, the track layout and the checkpoint indexes. 

        //The starting fuel of each participant is equal to the ASCII code of the first character of his name.

        //Track layout consists of zones represented by numbers, given on a single line separated by a single space.
        //Every number represents the fuel given or the fuel taken by the current zone of the track:
        //•	If the current zone is a checkpoint, the value of the zone is added to the driver's fuel. 
        //•	If the current zone is not a checkpoint, the value of the zone is subtracted from the driver's fuel.

        //Zones are indexed.Indexes are sequential and always start from zero (like an array).

        //The checkpoints are numbers, representing indexes that show if a zone of the track is a checkpoint. 
        //For example, you are given checkpoints 0, 3 and 5, that means that zones at index 0, 3 and 5 of the track are checkpoints 
        //therefore provide fuel for the driver.

        //Given this information, you need to check if a driver can finish and print the fuel that he is left with.
        //If a driver can't finish you need to print the zone he managed to reach. 

        //Input
        //The input will be read from the console.The input consists of exactly three lines:
        //•	The first line holds the drivers' names separated by a space: "{driver 1} {driver 2} … {driver N}"
        //•	On the second line is the track layout(zones) in the form of numbers separated by a space: "{zone 0} {zone 1} … {zone N}"
        //•	On the third line are the checkpoint indexes also separated by a space: "{index 0} {index 1} … {index N}"

        //Output
        //Print all drivers in the order of their appearance, each on a separate line:
        //•	If the driver finished, print his name and fuel left to the second digit after the decimal point in the format: "{driver name} - fuel left {fuel points}"
        //•	If the driver could not finish, print: "{driver name} - reached {zone index}"
        #endregion

        //reading all racers and sorting their properties out
        var contestants = new List<Racer>();

        var racersNames = Console.ReadLine().Split(' ').ToArray();
        foreach (var racer in racersNames)
        {
            var currentRacer = new Racer()
            {
                Name = racer,
                Fuel = racer.ToCharArray().First(), // first letter of names as ASCII = fuel
                IndexReached = 0
            };

            contestants.Add(currentRacer);
        }

        //reading the courses stats
        var course = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        var checkPoint = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        //acutalRace
        foreach (var currentRacer in contestants)
        {
            for (int index = 0; index < course.Count(); index++)
            {
                currentRacer.IndexReached = index;

                bool isCheckPoint = checkPoint.Contains(index);
                if (isCheckPoint)
                {
                    currentRacer.Fuel += course[index];
                }
                else // take away from driver
                {
                    currentRacer.Fuel -= course[index];

                    bool outOfFuel = currentRacer.Fuel <= 0;
                    if (outOfFuel) // continue on to next racer
                    {
                        break;
                    }
                }
            }
        }

        // print out each if passed, print gas left, if failed print index they failed on
        foreach (var currentRacer in contestants)
        {
            bool finishedRace = currentRacer.Fuel > 0;
            if (finishedRace)
            {
                Console.WriteLine($"{currentRacer.Name} - fuel left {currentRacer.Fuel:f2}");
            }
            else
            {
                Console.WriteLine($"{currentRacer.Name} - reached {currentRacer.IndexReached}");
            }
        }
    }
}