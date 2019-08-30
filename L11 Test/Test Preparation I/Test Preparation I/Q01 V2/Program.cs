using System;
using System.Globalization;
public class Program
{
    public static void Main()
    {
        string timeFormat = "HH:mm:ss";

        var startTime = DateTime.ParseExact(Console.ReadLine(), timeFormat, CultureInfo.InvariantCulture);

        int numberOfSteps = int.Parse(Console.ReadLine());
        int timePerStep = int.Parse(Console.ReadLine());

        ulong addedTime = (ulong)numberOfSteps * (ulong)timePerStep;

        var secondsToAddPerDay = addedTime % (24 * 60 * 60); // remove any excess days as it can overflow 9999 years

        var finalTime = startTime.AddSeconds(secondsToAddPerDay);

        Console.WriteLine($"Time Arrival: {finalTime.ToString(timeFormat)}");

    }
}