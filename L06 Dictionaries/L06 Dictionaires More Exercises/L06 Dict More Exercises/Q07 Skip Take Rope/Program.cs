using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Skip_Take_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToArray();

            var arrayOfNumbers = new List<int>();
            var arrayOfOtherChars = new List<char>();
            // seperating the numbers from other chars
            foreach (var charecter in input)
            {
                bool checkIfNumber = charecter >= 48 && charecter <= 57;
                if (checkIfNumber == true)
                {
                    arrayOfNumbers.Add(charecter - '0');
                }
                else
                {
                    arrayOfOtherChars.Add(charecter);
                }
            }

            var listOfOddNumbers = new List<int>();
            var listOfEvenNumbers = new List<int>();
            // seperating odd vs even ints
            for (int index = 0; index < arrayOfNumbers.Count; index++)
            {
                bool odd = index % 2 != 0;
                if (odd == true)
                {
                    listOfOddNumbers.Add(arrayOfNumbers[index]);
                }
                else
                {
                    listOfEvenNumbers.Add(arrayOfNumbers[index]);
                }
            }

            // until here its all good
            int counterOfOthersIndex = 0;
            string result = "";
            for (int index = 0; index < listOfEvenNumbers.Count; index++)
            {
                int numbersTaken = listOfEvenNumbers[index];
                string res = new string(arrayOfOtherChars.Skip(counterOfOthersIndex).Take(numbersTaken).ToArray());
                // I forgot to skip the already skipped ones from : counterOfOthersIndex
                result += res;
                counterOfOthersIndex += numbersTaken;

                int numbersSkipped = listOfOddNumbers[index];
                counterOfOthersIndex += numbersSkipped;
                
            }

            Console.WriteLine(result);
        }
    }
}
