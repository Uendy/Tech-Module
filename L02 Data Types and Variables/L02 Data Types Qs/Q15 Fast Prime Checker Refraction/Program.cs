using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q15_Fast_Prime_Checker_Refraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            for (int currentNumber = 2; currentNumber <= inputNumber; currentNumber++)
            {
                bool notPrime = true;
                for (int checkingNumber = 2; checkingNumber <= Math.Sqrt(currentNumber); checkingNumber++)
                {
                    if (currentNumber % checkingNumber == 0)
                    {
                        notPrime = false; // it's prime
                        break;
                    }
                }
                Console.WriteLine($"{currentNumber} -> {notPrime}");
            }

        }
    }
}
