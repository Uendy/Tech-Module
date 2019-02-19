using System;
using System.Collections.Generic;
using System.Globalization;

namespace Q01_Count_Working_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDateAsString = Console.ReadLine();
            var firstDate = DateTime.ParseExact(
                firstDateAsString,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture);

            var secondDateAsString = Console.ReadLine();
            var secondDate = DateTime.ParseExact(
                secondDateAsString,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture);

            var listOfHolidays = new List<string>();
            listOfHolidays.Add("01-01");// New Year Eve(1 Jan)
            listOfHolidays.Add("03-03");// Liberation Day(3 March)
            listOfHolidays.Add("01-05");// Worker’s day(1 May)
            listOfHolidays.Add("06-05");// Saint George’s Day(6 May)
            listOfHolidays.Add("24-05");// Saints Cyril and Methodius Day(24 May)
            listOfHolidays.Add("06-09");// Unification Day(6 Sept)
            listOfHolidays.Add("22-09");// Independence Day(22 Sept)
            listOfHolidays.Add("01-11");// National Awakening Day(1 Nov)
            listOfHolidays.Add("24-12");// 24th-12
            listOfHolidays.Add("25-12");// 25th-12
            listOfHolidays.Add("26-12");// Christmas(24, 25 and 26 Dec

            int workingDays = 0;
            //Q how to add days? and change holidays to the first 3 letters of the month
            // add days is not date.AddDays(1) but date = date.AddDays(1)
            //Month is in format MM so 2 digis 
            for (DateTime date = firstDate; date <= secondDate; date = date.AddDays(1))
            {
                bool itIsAHoliday = false;

                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }
                foreach (var holiday in listOfHolidays)
                {
                    if (date.Date.ToString("dd-MM") == holiday)
                    {
                        itIsAHoliday = true;
                        break;
                    }
                }
                if (itIsAHoliday == true)
                {
                    continue;
                }

                workingDays++;
            }

            Console.WriteLine(workingDays);
        }
    }
}
