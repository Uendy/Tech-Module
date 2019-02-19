using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            // I am incredibly proud of this one!

            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            if (array.Length == 1)
            {
                Console.WriteLine($"{array[0]} is already a condensed number");
                return;
            }

            int[] medianArray = new int[array.Length - 1];

            for (int allNumber = 0; allNumber < array.Length - 1; allNumber++)
            {

                for (int i = 0; i < array.Length-1; i++)
                {
                    medianArray[i] = array[i] + array[i + 1];
                }

                for (int updatingArray = 0; updatingArray < medianArray.Length; updatingArray++)
                {
                    array[updatingArray] = medianArray[updatingArray];
                }
            }

            Console.WriteLine(medianArray[0]);
        }
    }
}
