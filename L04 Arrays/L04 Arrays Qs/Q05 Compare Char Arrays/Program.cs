using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string[] secondInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int shorterStringLength = 0;

            string shorterString = "";
            string longestString = "";

            bool longerString = firstInput.Length > secondInput.Length;
            if (longerString == false) // sec >= first
            {
                shorterStringLength = firstInput.Length;

                for (int index = 0; index < firstInput.Length; index++)
                {
                    shorterString += firstInput[index];
                }
                for (int index = 0; index < secondInput.Length; index++)
                {
                    longestString += secondInput[index];
                }
            }
            else // first > sec
            {
                shorterStringLength = secondInput.Length;

                for (int index = 0; index < secondInput.Length; index++)
                {
                    shorterString += secondInput[index];
                }
                for (int index = 0; index < firstInput.Length; index++)
                {
                    longestString += firstInput[index];
                }
            }

            for (int index = 0; index < shorterStringLength; index++)
            {
                if (string.Compare(firstInput[index], secondInput[index]) == 0)
                {
                    continue;
                }
                else if (string.Compare(firstInput[index], secondInput[index]) < 0)
                {
                    Console.WriteLine(String.Join("", firstInput));
                    Console.WriteLine(String.Join("", secondInput));
                    return;
                }
                else if (String.Compare(firstInput[index], secondInput[index]) > 0)
                {
                    Console.WriteLine(String.Join("", secondInput));
                    Console.WriteLine(String.Join("", firstInput));
                    return;
                }
            }
            Console.WriteLine(shorterString);
            Console.WriteLine(longestString);
            // shorter string length if the shorter ends on the same letter as the longer
            // longer string length

        }
    }
}
