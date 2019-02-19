using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Q13_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputedNumber = int.Parse(Console.ReadLine());

            BigInteger result = 1;

            Console.WriteLine(GetFactorial(inputedNumber, result));
        }

        static BigInteger GetFactorial(int inputedNumber, BigInteger result)
        {
            for (int turn = 2; turn <= inputedNumber;)
            {
                result *= inputedNumber;
                inputedNumber--;

            }
            return result;
        }

        // or solve it with recursion, but idk how


    }
}
