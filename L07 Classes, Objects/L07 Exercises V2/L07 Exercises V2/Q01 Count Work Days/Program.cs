using System;
using System.Collections.Generic;
using System.Globalization;
public class Program
{
    //https://judge.softuni.bg/Contests/Practice/Index/210#0 - to check the questions
    public static void Main()
    {
        //Write a program that reads two dates in format dd-MM-yyyy and prints the number of working days between these two dates inclusive. 
        //Non -working days are:
        //•	All days that are Saturday or Sunday.
        //•	All days that are official holidays in Bulgaria:
        //  o New Year Eve(1 Jan)
        //  o Liberation Day(3 March)
        //  o Worker’s day(1 May)
        //  o Saint George’s Day(6 May)
        //  o Saints Cyril and Methodius Day(24 May)
        //  o Unification Day(6 Sept)
        //  o Independence Day(22 Sept)
        //  o National Awakening Day(1 Nov)
        //  o Christmas(24, 25 and 26 Dec)
        //All days not mentioned above are working and should count.

        var listOfVacations = new List<string>
        {
            "01-01",  // o New Year Eve(1 Jan)
            "03-03",  // o Liberation Day(3 March)
            "01-05",  // o Worker’s day(1 May)
            "06-05",  // o Saint George’s Day(6 May)
            "24-05",  // o Saints Cyril and Methodius Day(24 May)
            "06-09",  // o Unification Day(6 Sept)
            "22-09",  // o Independence Day(22 Sept)
            "01-11",  // o National Awakening Day(1 Nov)
            "24-12",  // o Christmas(24, 25 and 26 Dec)
            "25-12",  // 25 and 
            "26-12"   // 26 Dec
        };

        var startDateString = Console.ReadLine();
        var startDate = DateTime.ParseExact(startDateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        var endDateString = Console.ReadLine();
        var endDate = DateTime.ParseExact(endDateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        int workDays = 0;

        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            bool weekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday; // check if weekend
            if (weekend)
            {
                continue;
            }

            var currentDate = date.Date.ToString("dd-MM"); //gets date in dd-MM format, same as in the listOfVacations
            bool isVacation = listOfVacations.Contains(currentDate);
            if (isVacation)
            {
                continue;
            }

            workDays++;
        }

        Console.WriteLine(workDays);
    }
}