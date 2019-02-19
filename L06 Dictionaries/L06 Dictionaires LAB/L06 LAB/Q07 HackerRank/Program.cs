using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            var phoneBook = new Dictionary<string, string>();

            for (int index = 0; index < numberOfInputs; index++)
            {
                string input = Console.ReadLine();

                

                string keyName = "";
                int indexOfWhileCycle = 0;
                while (input[indexOfWhileCycle] != ' ')
                {
                    keyName += input[indexOfWhileCycle];
                    indexOfWhileCycle++;
                }

                int newIndexForValue = ++indexOfWhileCycle;
                string valueNumber = "";
                for (int indexValue = newIndexForValue; indexValue < input.Length; indexValue++)
                {
                    valueNumber += input[indexValue];
                    indexValue++;
                }

                //phoneBook["{keyName}"] = valueNumber;
            }
        }
    }
}
