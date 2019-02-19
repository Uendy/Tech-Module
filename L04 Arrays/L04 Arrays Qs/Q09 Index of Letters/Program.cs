using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q09_Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int arrayLength = input.Length;

            string[] finalArray = new string[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                finalArray[i] = input[i] + " -> " + 
                    (input[i] - 'a');
            }

            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine(finalArray[i]);
            }
        }
    }
}
