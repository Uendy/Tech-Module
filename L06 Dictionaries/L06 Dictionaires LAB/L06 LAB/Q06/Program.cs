using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfInts =  Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

            int k = listOfInts.Length / 4;

            int[] row1left = listOfInts
                .Take(k)
                .Reverse()
                .ToArray();

            int[] row1right = listOfInts
                .Reverse()
                .Take(k)
                .ToArray();

            int[] row1 = row1left
                .Concat(row1right)
                .ToArray();

            int[] row2 = listOfInts
                .Skip(k)
                .Take(2 * k)
                .ToArray();

            var sumArr =
              row1.Select((x, index) => x + row2[index]);

            Console.WriteLine(string.Join(" ", sumArr));

        }
    }   }
