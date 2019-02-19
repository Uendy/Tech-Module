using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine() 
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            for (int index = 0; index < input.Count; index++)
            {
                int currentNumber = input[index];

                char[] charArray = currentNumber.ToString().ToCharArray(); // Int -> Array through ToCharArray()
                charArray.Reverse();

                string alreadyReversedString = "";

                for (int innerIndex = charArray.Length-1; innerIndex >= 0; innerIndex--)
                {
                    alreadyReversedString += charArray[innerIndex];
                }

                currentNumber = Convert.ToInt32(alreadyReversedString);
                sum += currentNumber;
                
            }

            Console.WriteLine(sum);
        }
    }
}
