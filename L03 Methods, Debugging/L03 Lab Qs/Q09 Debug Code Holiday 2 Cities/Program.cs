using System;
using System.Globalization;

namespace Q09_Debug_Code_on_Holiday
{

    class HolidaysBetweenTwoDates
    {
        static void Main()
        {
            //This was hell to find : it gave me little m = minuts instead of big M = months!
            var startDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);

            var endDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);

            var holidaysCount = 0;
            var end = endDate;

            for (var date = startDate; date <= end; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    holidaysCount++;
                }
            }

            Console.WriteLine(holidaysCount);
        }
    }
}
