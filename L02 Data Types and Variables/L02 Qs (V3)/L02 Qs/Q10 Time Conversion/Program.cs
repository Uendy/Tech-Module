using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Write program to enter an integer number of centuries and convert it to years, days, hours, minutes, seconds, milliseconds, microseconds, nanoseconds.

        // Example:

        // Input:   Output:
        // 1	       1 centuries = 100 years = 36524 days = 876576 hours = 52594560 minutes = 3155673600 seconds = 3155673600000 milliseconds = 3155673600000000 microseconds = 3155673600000000000 nanoseconds

        // Reading input:

        int centuries = int.Parse(Console.ReadLine());

        // Converting to all other times:

        int years = centuries * 100;
        int days = (int)(years * 365.2422);
        int hours = days * 24;
        decimal minutes = hours * 60M;
        decimal seconds = minutes * 60M;
        decimal milliseconds = seconds * 1000M;
        decimal microseconds = milliseconds * 1000;
        decimal nanoseconds = microseconds * 1000;

        // Printing output:
        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {nanoseconds} nanoseconds");
    }
}