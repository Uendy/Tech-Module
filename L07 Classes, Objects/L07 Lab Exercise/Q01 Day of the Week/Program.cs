using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01_Day_of_the_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] date = Console.ReadLine()
                .Split('-')
                .Select(int.Parse)
                .ToArray();

            int day = date[0];
            int month = date[1];
            int year = date[2];
            DateTime realDate = new DateTime(year, month, day);

            Console.WriteLine(realDate.DayOfWeek);
        }
    }
}
