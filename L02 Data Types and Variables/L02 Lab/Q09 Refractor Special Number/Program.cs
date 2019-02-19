using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q09_Refractor_Special_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxDigit = int.Parse(Console.ReadLine());
            int sumOfDigits = 0;
            bool checkSpecialness = false;

            for (int currentNumber = 1; currentNumber <= maxDigit; currentNumber++)
            {
                int testDigit = currentNumber;
                while (testDigit > 0)
                {
                    sumOfDigits += testDigit % 10;
                    testDigit = testDigit / 10;
                }
                checkSpecialness = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                Console.WriteLine($"{currentNumber} -> {checkSpecialness}");
                sumOfDigits = 0;
            }

        }
    }
}
