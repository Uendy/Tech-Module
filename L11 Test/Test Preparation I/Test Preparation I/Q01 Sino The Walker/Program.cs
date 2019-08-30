using System;
using System.Globalization;
public class Program
{
    public static void Main()
    {
        //check questions at:https://judge.softuni.bg/Contests/Practice/Index/445#0

        #region
        //You will receive the time that Sino leaves SoftUni, the steps taken and time for each step in seconds. 
        //You need to print the exact time that he will arrive at home in the format specified.

        //Input / Constrains
        //•	The first line will be the time Sino leaves SoftUni in the following format: HH: mm: ss
        //•	The second line will contain the number of steps that he needs to walk to his home.
        //This number will be an integer in range[0…2, 147, 483, 647]
        //•	On the final line you will receive the time in seconds for each step. This number will be an integer in range[0…2, 147, 483, 647]

        //Output
        //•	Print the time of arrival at home in the following format:
        //o   Time Arrival: { hours}:{ minutes}:{ seconds}
        //•	If hours, minutes or seconds are a single digit number, add a zero in front.
        //•	If, for example, hours are equal to zero, print a 00 in their place.The same is true for minutes or seconds.
        //•	Time of day starts at 00:00:00 and ends at 23:59:59
        #endregion

        string timeFormat = "HH:mm:ss";

        var startTime = DateTime.ParseExact(Console.ReadLine(), timeFormat, CultureInfo.InvariantCulture);

        int numberOfSteps = int.Parse(Console.ReadLine());
        int timePerStep = int.Parse(Console.ReadLine());

        long totalTime = numberOfSteps * timePerStep;

        var arrivalTime = startTime.AddSeconds(totalTime);

        Console.WriteLine($"Time Arrival: {arrivalTime.ToString(timeFormat)}");
    }
}