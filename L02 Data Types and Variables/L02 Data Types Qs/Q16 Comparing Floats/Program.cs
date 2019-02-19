using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q16_Comparing_Floats
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that safely compares floating - point numbers(double) with precision eps = 0.000001

            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double differenceBetween = Math.Abs(firstNumber - secondNumber);
            double eps = 0.000001;

            bool diffSmallerThanEPS = differenceBetween <= eps;             //false so they aren't the same

            Console.WriteLine(diffSmallerThanEPS);
        }
    }
}
