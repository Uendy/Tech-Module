using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int kLength = array.Length / 4;
            int lengthOfAnswes = (array.Length / 2);
            int[] arrayOfAnswers = new int[lengthOfAnswes];

            //int[] quad = new int[kLength];

            for (int quadruplette = 0; quadruplette < kLength; quadruplette++) // depending on how many quads we have
            {

                for (int index = 0; index < 2 + 1; index++)
                {
                    arrayOfAnswers[index] = array[(quadruplette * kLength + index)] + array[(quadruplette * kLength - index + kLength)];
                }
            }

            Console.WriteLine(String.Join(" ", arrayOfAnswers));
        }
    }
}
