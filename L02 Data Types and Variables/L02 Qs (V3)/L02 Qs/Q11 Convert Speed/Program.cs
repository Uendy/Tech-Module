using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Create a program to ask the user for a distance (in meters) and the time taken (as three numbers: hours, minutes, seconds), and print the speed, in meters per second, kilometers per hour and miles per hour.

        // Assume 1 mile = 1609 meters.

        // •	On first line you receive – distance in meters
        // •	On second – hours
        // •	On third – minutes
        // •	On fourth – seconds


        // Every number in the output should be precise up to 6 digits after the floating point
        // •	On first line – speed in meters per second(m / s)
        // •	On second line – speed in kilometers per hour(km / h)
        // •	On third line – speed in miles per hour(mph)

        // Input:       Output:
        //  1000       0.2732241
        //  1          0.9836066
        //  1          0.6113155
        //  0   

        // Reading input:
        long meters = long.Parse(Console.ReadLine());
        int hours = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());
        int seconds = int.Parse(Console.ReadLine());

        // Calculations:

        //// Converting total time to seconds:
        long hoursInSec = hours * 3600; // 3600, hours to seconds
        long minInSec = minutes * 60; 
        long totalSeconds = hoursInSec + minInSec + seconds;
        double metersPerSeconds = (double) meters / totalSeconds;

        //// Converting total time in hours:
        double totalHours = (double) totalSeconds / 3600;

        double kilometers = (double) meters / 1000;

        double kilometersPerHour = kilometers / totalHours;

        //// Converting to Miles
        double miles = (double) meters / 1609; // meters to miles = 1609 in description
        double milesPerHour = miles / totalHours;

        // Rounding and Printing output:
        Console.WriteLine(Math.Round(metersPerSeconds, 5));
        Console.WriteLine(Math.Round(kilometersPerHour, 5));
        Console.WriteLine(Math.Round(milesPerHour, 5));
    }
}