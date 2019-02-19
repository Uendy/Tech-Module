using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_Multiply_Evens_and_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int readNumber = Math.Abs(int.Parse(Console.ReadLine()));

            NumberBreaker(readNumber);

        }

        static void NumberBreaker(int readNumber)
        {
            int oddNumber = 0;
            int evenNumber = 0;
            int precheck = 0;
            
            for (int digit = 1; readNumber > 0; digit++)
            {
                precheck = readNumber % 10;

                if (precheck % 2 == 0)
                {
                    evenNumber += precheck;
                }
                else
                {
                    oddNumber += precheck;
                }
                readNumber /= 10;
            }
            EvenOddSummer(evenNumber, oddNumber);

        }

        static int EvenOddSummer(int evenNumber, int oddNumber)
        {
            int totalMultiplication = evenNumber* oddNumber;
            Console.WriteLine(totalMultiplication);
            return totalMultiplication;
        }
    }
}
