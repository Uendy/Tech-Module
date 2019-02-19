using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.Parse(Console.ReadLine());
            
            int[] leftForPrimes = new int[max - 1]; // since 0 & 1 is not prime 
            // to put them into the array
            int sum = 2;
            for (int index = 0; index < leftForPrimes.Length; index++)
            {
                leftForPrimes[index] = sum++;
            }

            int currentSmallestDenominator = 2;
            while (currentSmallestDenominator < Math.Sqrt(max)) // I believe the mistake is here
            {
                for (int multipleOfCurrentDenom = 2; multipleOfCurrentDenom <= max/currentSmallestDenominator; multipleOfCurrentDenom++)
                {
                    for (int primeIndexCheck = 0; primeIndexCheck < leftForPrimes.Length; primeIndexCheck++)
                    {
                        bool primeCheck = currentSmallestDenominator * multipleOfCurrentDenom == leftForPrimes[primeIndexCheck];
                        if (primeCheck == true)
                        {
                            leftForPrimes[primeIndexCheck] = 0;
                        }
                    }
                }
                currentSmallestDenominator++;
            }

            // to put it into a string and print
            string primes = "";
            for (int index = 0; index < leftForPrimes.Length; index++)
            {
                if (leftForPrimes[index] != 0)
                {
                    primes += leftForPrimes[index] + " ";
                }
            }

            Console.WriteLine(primes.TrimEnd());
        }
    }
}
