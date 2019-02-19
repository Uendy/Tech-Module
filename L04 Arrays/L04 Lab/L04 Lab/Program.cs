using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L04_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfTheWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            double selectedDate = Math.Round(double.Parse(Console.ReadLine()) - 1);

            if (selectedDate < 0 || selectedDate >= 7)
            {
                Console.WriteLine("Invalid Day!");
            }
            else
            {
                Console.WriteLine(daysOfTheWeek[(int)selectedDate]);
            }


            //or their solution
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int day = int.Parse(Console.ReadLine());

            if (day >= 1 && day <= 7)
                Console.WriteLine(days[day - 1]);
            else
                Console.WriteLine("Invalid day!");



        }
    }
}
