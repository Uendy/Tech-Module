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

            BigInteger factResult = (GetFactorial(inputedNumber, result));

            Console.WriteLine(GetTerminalZeroes(factResult));
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

        static int GetTerminalZeroes(BigInteger factResult)
        {

            int amountOfZeroes = 0;

            while (factResult % 10 == 0)
            {
                amountOfZeroes++;
                factResult /= 10;
            }

            return amountOfZeroes;
        }
    }
}
