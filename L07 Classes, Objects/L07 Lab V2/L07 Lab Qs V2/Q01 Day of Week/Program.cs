using System;
using System.Linq;
public class Program
{
    //https://judge.softuni.bg/Contests/Practice/Index/175#0 check questions
    public static void Main()
    {
        //You are given a date in format day-month-year. Calculate and print the day of week in English.
        var input = Console.ReadLine().Split('-').ToArray();

        int day = int.Parse(input[0]);
        int month = int.Parse( input[1]);
        int year = int.Parse(input[2]);

        var currentDateTime = new DateTime(year, month, day);

        Console.WriteLine(currentDateTime.DayOfWeek);
    }
}