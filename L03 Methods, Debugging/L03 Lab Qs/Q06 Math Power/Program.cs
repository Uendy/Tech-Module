using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());
            Console.WriteLine(PowerCalculator(baseNumber, pow));
        }

        static double PowerCalculator(double baseNumber, double Pow)
        {
            double result = 1;
            for (int i = 1; i <= Pow; i++)
            {
                result *= baseNumber;
            }
            return result;
        }
    }
}
