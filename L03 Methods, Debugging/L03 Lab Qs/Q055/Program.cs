using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q055
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tempreture in Celcius:" + FahrenToCelcius());
        }

        static double FahrenToCelcius()
        {
            double fahrenheit = double.Parse(Console.ReadLine());
            double celcius = Math.Round(((fahrenheit - 32) * 5 / 9),2);
            return celcius;
        }
    }
}
