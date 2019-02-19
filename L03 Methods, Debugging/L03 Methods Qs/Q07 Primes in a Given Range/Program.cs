using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Primes_in_a_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNumber = int.Parse(Console.ReadLine());
            int endingNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(PrimesInRange(startingNumber, endingNumber));
        }

        static string PrimesInRange(int startNumber, int endNumber)
        {
            List<int> list = new List<int>();

            for (int checkedNumber = startNumber; checkedNumber <= endNumber; checkedNumber++)
            {
                if (checkedNumber < 2)
                { continue; }

                bool isPrime = true;
                for (int primeCheck = 2; primeCheck <= Math.Sqrt(checkedNumber); primeCheck++)
                {
                    if (checkedNumber % primeCheck == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime == true)
                {
                    list.Add(checkedNumber);
                }
            }

            string primes = null;
            
            var lastItem = list[list.Count - 1];

            foreach (var item in list)
            {
                if (item == lastItem)
                {
                    primes += item;
                }
                else
                primes += item + ", ";
                
            }
            

            return primes;
        }
    }
}
