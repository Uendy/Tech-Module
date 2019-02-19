using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] secondArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int counter = 0;
            int oldCounter = 0;

            for (int firstWord = 0; firstWord < firstArray.Length; firstWord++)
            {
                bool noMatchSoFar = true;
                string firstCheckedWord = firstArray[firstWord];

                for (int secondWord = 0; secondWord < secondArray.Length; secondWord++)
                {
                    string secondCheckedWord = secondArray[secondWord];

                    bool sameStringCheck = firstCheckedWord == secondCheckedWord;

                    if (sameStringCheck == true)
                    {
                        noMatchSoFar = false;
                        break;
                    }
                }

                bool biggerCounter = counter >= oldCounter;

                if (noMatchSoFar == false)
                {
                    counter++;
                }
                else
                {
                    if (biggerCounter == true)
                    {
                        oldCounter = counter;
                        counter = 0;
                    }
                    else
                    { counter = 0; }
                }
            }

            Console.WriteLine(Math.Max(oldCounter,counter));
        }
    }
}
