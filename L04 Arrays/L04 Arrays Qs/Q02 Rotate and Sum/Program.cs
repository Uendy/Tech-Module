using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] sameIndex = new int[array.Length];
            int turns = int.Parse(Console.ReadLine());

            for (int index = 0; index < array.Length; index++)
            {

                for (int addition = 0; addition < turns; addition++)
                {
                        sameIndex[index] += array[(index + addition) % array.Length];
                }
            }

            // to put them in the right order after the index switch
            int[] finalIndex = new int[sameIndex.Length];

            for (int oldIndex = 0; oldIndex < array.Length; oldIndex++)
            {
                finalIndex[oldIndex] = sameIndex[((oldIndex + turns) % array.Length)]; //% sameIndex.Length];
            }
            Console.WriteLine(String.Join(" ", finalIndex));
        }
    }
}
