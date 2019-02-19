using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long inputNumber = long.Parse(Console.ReadLine());

            Console.WriteLine(PrimeChecker(inputNumber));
        }

        static bool PrimeChecker(long inputNumber)
        {
            bool isPrime = false;

            if (inputNumber <= 1)
            {
                return isPrime;
            }
            else
            {

                for (int checkedNumber = 2; checkedNumber <= Math.Sqrt(inputNumber); checkedNumber++)
                {
                    if (inputNumber % checkedNumber == 0)
                    {
                        return isPrime == true;
                    }
                }
            }
            return isPrime == false;

        }
    }
}
