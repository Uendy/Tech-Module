using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Fold_and_Sum_P2
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfInts = new List<int>();
            listOfInts = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

            var length = listOfInts.Count / 4;

            var firstRowLeft = listOfInts
                .Take(length)
                .Reverse()
                .ToArray();

            var firstRowRight = new List<int>(listOfInts);
            firstRowRight.Reverse();
            firstRowRight.Take(length)
                .ToArray();

            var firstRow = firstRowLeft
                .Concat(firstRowRight)
                .ToArray();

            var secondRow = listOfInts
                .Skip(length)
                .Take(2 * length)
                .ToArray();

                firstRow
                .Zip(secondRow, (x,y) => x+y)// does the function to both to a collection
                .ToList()
                .ForEach(Console.WriteLine);  // does both to a collection

        }
    }
}
