using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] finalArray = new int[array.Length/2];
            int firstHalfOfFinalArraySum = (array.Length / 2) - 1;
            int secondHalfFinalArraySum = (2 * (array.Length - 1)) - firstHalfOfFinalArraySum;

            // for the first half
            for (int i = 0; i < finalArray.Length/2; i++)
            {
                finalArray[i] = array[((finalArray.Length / 2)-1) - i] + array[firstHalfOfFinalArraySum - ((finalArray.Length / 2) -1) + i]; 
            }

            // for the 2nd half
            for (int j = 0;  j < finalArray.Length/2; j++)
            {
                finalArray[j + finalArray.Length / 2] = array[finalArray.Length + j] + array[secondHalfFinalArraySum - finalArray.Length - j]; 
            }

            Console.WriteLine(String.Join(" ",finalArray));
        }
    }
}
