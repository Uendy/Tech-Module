using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            
            char[] array = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            int longestCounter = 1;
            char elementRepeated = array[0];
            int oldestLongestCouter = 0;

            for (int index = 1; index < array.Length; index++)
            {
                bool equalElementCheck = array[index] == array[index - 1];

                if (equalElementCheck == true)
                {
                    longestCounter++;

                    if (index == array.Length - 1)
                    {
                        if (longestCounter > oldestLongestCouter)
                        {
                            elementRepeated = array[index - 1];
                            oldestLongestCouter = longestCounter;
                        }
                    }
                }
                else
                {
                    if (longestCounter > oldestLongestCouter)
                    {
                        elementRepeated = array[index - 1];
                        oldestLongestCouter = longestCounter;
                    }

                    longestCounter = 1;

                }
            }

            int longest = Math.Max(longestCounter, oldestLongestCouter);

            string output = "";
            for (int i = 0; i < longest; i++)
            {
                output += elementRepeated + " ";
            }

            Console.WriteLine(output.TrimEnd());
        }
    }
}
