using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Q01_Day_of_the_Week_Part_2
{
    public class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();
            double randomNumber = rnd.Next(int.MinValue, int.MaxValue);
            Console.WriteLine(randomNumber);

            string inputDate = Console.ReadLine();

            DateTime date = DateTime.ParseExact(inputDate, "d-M-yyyy", CultureInfo.InvariantCulture);
            // must be using (using System.Globalization)

            Console.WriteLine(date.DayOfWeek);

        }
    }
}
