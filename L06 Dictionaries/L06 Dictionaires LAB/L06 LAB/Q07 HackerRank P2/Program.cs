using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_HackerRank_P2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            var phoneBook = new Dictionary<string, string>();

            for (int indexOfInput = 0; indexOfInput < numberOfInputs; indexOfInput++)
            {
                var listOfCurrentStrings = new List<string>();
                listOfCurrentStrings = Console.ReadLine()
                    .Split(' ')
                    .Select(x => x)
                    .ToList();

                phoneBook[listOfCurrentStrings[0]] = listOfCurrentStrings[1];
            }

            for (int indexOfOutput = 0; indexOfOutput < numberOfInputs; indexOfOutput++)
            {
                string searchedValueName = Console.ReadLine();

                bool inPhoneBook = phoneBook.ContainsKey(searchedValueName);

                if (inPhoneBook == true)
                {
                    Console.WriteLine($"{searchedValueName}={phoneBook[searchedValueName]}");
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
        }
    }
}
