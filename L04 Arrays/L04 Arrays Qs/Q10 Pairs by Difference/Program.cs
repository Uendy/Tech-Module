using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10_Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int diff = int.Parse(Console.ReadLine());
            int pairsWithExactDiff = 0;

            for (int firstIndex = 0; firstIndex < array.Length; firstIndex++)
            {
                for (int secondIndex = firstIndex; secondIndex < array.Length; secondIndex++)
                {
                    bool exactDiffCheck = Math.Abs(array[firstIndex] - array[secondIndex]) == diff;
                    if (exactDiffCheck == true)
                    {
                        pairsWithExactDiff++;
                    }
                }
            }

            Console.WriteLine(pairsWithExactDiff);
        }
    }
}
