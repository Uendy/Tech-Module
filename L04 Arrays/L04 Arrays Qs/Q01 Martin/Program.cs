using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();
            var shorterArr = Math.Min(arr1.Length, arr2.Length);

            int counterLeft = 0;
            int counterRight = 0;

            for (int i = 0; i < shorterArr; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    counterLeft++;
                }

            }

            for (int i = 1; i <= shorterArr; i++)
            {
                if (arr1[arr1.Length - i] == arr2[arr2.Length - i])
                {
                    counterRight++;
                }

            }

            Console.WriteLine(Math.Max(counterLeft, counterRight));
        }
    }
}
