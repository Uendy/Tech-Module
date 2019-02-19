using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Odd_Occurances
{
    class Program
    {
        static void Main(string[] args)
        {
            var tableOfContents = new Dictionary<string, int>();
            string[] input = Console.ReadLine()
                .ToLower()
                .Split(' ')
                .ToArray();

            for (int index = 0; index < input.Length; index++)
            {
                bool keyAlreadyPresent = tableOfContents.ContainsKey(input[index]);
                if (keyAlreadyPresent == true)
                {
                    tableOfContents[input[index]]++;
                }
                else
                {
                    tableOfContents[input[index]] = 1;
                }
            }

            var notEven = new List<string>();

            foreach (var item in tableOfContents)
            {
                bool checkIfOddOccurances = item.Value % 2 != 0;
                if (checkIfOddOccurances == true)
                {
                    notEven.Add(item.Key);
                }
            }

            string output = String.Join(", ", notEven);
            Console.WriteLine(output);
        }
    }
}
