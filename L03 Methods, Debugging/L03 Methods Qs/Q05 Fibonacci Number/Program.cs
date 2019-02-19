using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Fibonacci_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            FibonacciFinder(inputNumber);
        }
        static void FibonacciFinder(int inputNumber)
        {
            int firstNumber = 1;
            int secondNumber = 1;

            if (inputNumber <= 1)
            { Console.WriteLine(1); }

            for (int i = 2; i <= inputNumber; i++)
            {
                if (i % 2 == 0) //even ones
                {
                    firstNumber = firstNumber + secondNumber;
                    if (inputNumber == i)
                    { Console.WriteLine(firstNumber); }
                }

                else // odd
                {
                    secondNumber = firstNumber + secondNumber;
                    if (inputNumber == i)
                    { Console.WriteLine(secondNumber); }
                }
            }
        }
    }
}
