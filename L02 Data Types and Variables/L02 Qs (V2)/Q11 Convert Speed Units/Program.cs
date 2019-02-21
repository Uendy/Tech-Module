using System;

public class Program
{
    public static void Main()
    {
        //Create a program to ask the user for a distance (in meters) and the time taken (as three numbers: hours, minutes, seconds), and print the speed, in meters per second, kilometers per hour and miles per hour.

        float distanceTravelled = float.Parse(Console.ReadLine());

        float hoursTaken = float.Parse(Console.ReadLine());
        float minutesTaken = float.Parse(Console.ReadLine());
        float secondsTaken = float.Parse(Console.ReadLine());

        float totalSeconds = secondsTaken + minutesTaken * 60 + hoursTaken * 3600; //whole time converted 
        float metersPerSeconds = distanceTravelled / totalSeconds;
        Console.WriteLine(metersPerSeconds);

        float totalHours = secondsTaken / 3600 + minutesTaken / 60 + hoursTaken;
        float kiloMetersTravelled = distanceTravelled / 1000;                                 //km/h
        float kilometersPerHour = kiloMetersTravelled / totalHours;
        Console.WriteLine(kilometersPerHour);

        float milesTravelled = distanceTravelled / 1609;
        float milesPerHour = milesTravelled / totalHours; //mph
        Console.WriteLine(milesPerHour);
    }
}
