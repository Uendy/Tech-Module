using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Sign_of_Integer_Number
{
    class Program
    {
        static int inputNumber = int.Parse(Console.ReadLine());

        static void Main(string[] args)
        {
            SignChecker(inputNumber);
        }

        static void SignChecker(int inputNumber)
        {
            if (inputNumber >= 1)
            {
                Console.WriteLine($"The number {inputNumber} is positive.");
            }
            else if (inputNumber <= -1)
            {
                Console.WriteLine($"The number {inputNumber} is negative.");
            }
            else
            {
                Console.WriteLine("The number 0 is zero.");
            }
        }

    }
}
