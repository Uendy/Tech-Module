using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Plamen_Tast_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            //accept n (size of array) and put it into an array and then push each index by k

            int[] inputedValues = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int size = inputedValues[0];
            int indexAdder = inputedValues[1];

            string output = "";

            int[] array = new int[size];

            int[] inputArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int initialIndex = 0; initialIndex < size; initialIndex++)
            {
                array[initialIndex] = inputArray[initialIndex];

                    bool aboveMaxIndex = initialIndex + indexAdder >= size;

                    if (aboveMaxIndex == true)
                    {
                        array[initialIndex] = inputArray[initialIndex + indexAdder - size];
                    }
                    else
                    {
                        array[initialIndex] = inputArray[initialIndex + indexAdder];
                    }

                output += array[initialIndex] + " ";
            }

            Console.WriteLine(output.TrimEnd());
        }
    }
}
