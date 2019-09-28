using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //The Nascar Qualifications are about to begin. You are tasked with creating a program that outputs the results from the race. 
        //On the first line you will be given the names of the racers on their positions in the beginning of the race.
        //On the next line, you will be given the following pairs – “{command} {racer}|{command} {racer}……”.

        //You may receive the following types of commands:
        //•	Race { racer} – add the pilot on the last position, if he isn’t in the race.
        //•	Accident { racer} – remove the racer from the race.
        //•	Box { racer} – move the racer one position back, if he is in the race and he is not already last.
        //•	Overtake { racer} { racersCount} – move the racer the given count of positions forward, if he is in the race and the position is valid.
        // Read commands until you receive “end”.

        //Input / Consrtaints
        //•	On the first line, you will be given the names of the racers on their positions.
        //•	On the second line, you will be given the pairs – { command} { racer} in the format described above.
        //•	There will always be at least one racer in the race.
        //•	The commands will always be valid.

        //Output
        //•	At the end of the race, print the list with the names of the racers, separated by “~”.

        var racers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string input = Console.ReadLine();
        while (input != "end")
        {
            var inputTokens = input.Split(' ').ToArray();

            string command = inputTokens[0];
            string pilot = inputTokens[1];

            switch (command)
            {

                case "Race":
                    racers = AddRacer(racers, pilot);
                    break;

                case "Accident":
                    racers = RemoveRacer(racers, pilot);
                    break;

                case "Box":
                    racers = MoveBack(racers, pilot);
                    break;

                case "Overtake":
                    int position = int.Parse(inputTokens[2]);
                    racers = RacerOvertakes(racers, pilot, position);
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }

        string outPut = string.Join(" ~ ", racers);
        Console.WriteLine(outPut);

    }

    //•	Overtake { racer} { racersCount} – move the racer the given count of positions forward, if he is in the race and the position is valid.
    public static List<string> RacerOvertakes(List<string> racers, string pilot, int position)
    {
        bool racerExists = racers.Contains(pilot);
        if (racerExists)
        {
            int currentIndexOfRacer = racers.IndexOf(pilot);
            int newPosition = currentIndexOfRacer - position;

            bool validPosition = newPosition >= 0 && newPosition < racers.Count();
            if (validPosition)
            {
                racers.Remove(pilot);
                racers.Insert(newPosition, pilot);
            }
        }

        return racers;
    }

    //•	Box { racer} – move the racer one position back, if he is in the race and he is not already last.
    public static List<string> MoveBack(List<string> racers, string pilot)
    {
        bool racerExists = racers.Contains(pilot);
        int currentIndex = racers.IndexOf(pilot);
        bool alreadyLast = currentIndex == racers.Count() - 1;
        if (racerExists && !alreadyLast)
        {
            racers.Remove(pilot);
            racers.Insert(currentIndex + 1, pilot);
        }

        return racers;
    }

    //•	Accident { racer} – remove the racer from the race.
    public static List<string> RemoveRacer(List<string> racers, string pilot)
    {
        bool racerExists = racers.Contains(pilot);
        if (racerExists)
        {
            racers.Remove(pilot);
        }

        return racers;
    }

    //	Race { racer} – add the pilot on the last position, if he isn’t in the race.
    public static List<string> AddRacer(List<string> racers, string pilot)
    {
        bool newRacer = !racers.Contains(pilot);
        if (newRacer)
        {
            racers.Add(pilot);
        }

        return racers;
    }
}