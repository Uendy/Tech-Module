using System;
using System.Globalization;
public class Program
{
    public static void Main()
    {
        //You are given a date in format day-month-year. Calculate and print the day of week in English.
        var date = Console.ReadLine();

        var currentDateTime = DateTime.ParseExact(date, "d-M-yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine(currentDateTime.DayOfWeek);
    }
}