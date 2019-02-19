using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Odd_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            input.RemoveAll(x => x % 2 != 0);

            var copiedListOfInts = input;

            for(int index = 0; index < input.Count; index++)
            { 
                bool checkIfAboveAverage = copiedListOfInts[index] > input.Average();
                if (checkIfAboveAverage == true)
                {
                    copiedListOfInts[index]++;
                }
                else
                {
                    copiedListOfInts[index]--;
                }
            }

            

             Console.WriteLine(String.Join(" ", copiedListOfInts));
        }
    }
}
