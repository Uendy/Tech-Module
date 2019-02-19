using System;
using System.Linq;
using System.Globalization;
    class Program
    {
        static void Main(string[] args)
        {
            string firstDateAsString = Console.ReadLine();
            var firstDate = DateTime.ParseExact(
                firstDateAsString,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture);

            string secondDateAsString = Console.ReadLine();
            var secondDate = DateTime.ParseExact(
                secondDateAsString,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture);

            string[] holidays = new string[11];
            holidays[0] = ("01-01");// New Year Eve(1 Jan)
            holidays[1] = ("03-03");// Liberation Day(3 March)
            holidays[2] = ("01-05");// Worker’s day(1 May)
            holidays[3] = ("06-05");// Saint George’s Day(6 May)
            holidays[4] = ("24-05");// Saints Cyril and Methodius Day(24 May)
            holidays[5] = ("06-09");// Unification Day(6 Sept)
            holidays[6] = ("22-09");// Independence Day(22 Sept)
            holidays[7] = ("01-11");// National Awakening Day(1 Nov)
            holidays[8] = ("24-12");// 24th-12
            holidays[9] = ("25-12");// 25th-12
            holidays[10] = ("26-12");// Christmas(24, 25 and 26 Dec

            int workingDays = 0;

            for (DateTime date = firstDate; date <= secondDate; date = date.AddDays(1))
            {
                var currentDate = date.ToString("dd-MM");
                bool itIsAHoliday = false;
                bool weekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
                if (weekend == true)
                {
                    continue;
                }
                else if (holidays.Contains(currentDate))
                {
                    itIsAHoliday = true;
                    continue;
                }
                else if (itIsAHoliday == true)
                {
                    continue;
                }

                workingDays++;
            }

            Console.WriteLine(workingDays);
        }
    }
