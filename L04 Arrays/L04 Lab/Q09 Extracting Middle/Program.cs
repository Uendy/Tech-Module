using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q09_Extracting_Middle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split (new char [] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            if (inputArray.Length == 1)
            {
                Console.WriteLine($"{{ {inputArray[0]} }}");
            }
            else if (inputArray.Length % 2 == 0) // even
            {
                int firstMiddleElement = inputArray.Length / 2;
                Console.WriteLine($"{{ {inputArray[firstMiddleElement-1]}, {inputArray[firstMiddleElement]} }}");
            }
            else if (inputArray.Length % 2 != 0) // odd
            {
                double exactMiddleElement = Math.Floor(inputArray.Length / 2.0);
                Console.WriteLine($"{{ {inputArray[(int)exactMiddleElement-1]}, {inputArray[(int)exactMiddleElement]}, {inputArray[(int)exactMiddleElement+1]} }}");
            }
        }
    }
}
