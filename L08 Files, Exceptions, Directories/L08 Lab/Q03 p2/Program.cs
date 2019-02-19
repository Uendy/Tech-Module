using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Q03_p2
{
    class Program
    {
        static void Main(string[] args)
        {
            var specialWords = Console.ReadLine().Split(' ').ToArray();

            var dictOfSpecialWords = new Dictionary<string, int>();
            foreach (var word in specialWords)
            {
                dictOfSpecialWords[word] = 0;
            }

            var inputAsStringArray = File.ReadAllText("Input.txt")
                .ToLower()
                .Split(new char[] { ' ', '.', '!', '?', '-', '\'', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToArray(); // terrrible to remember syntax, but useful

            foreach (string word in inputAsStringArray)
            {
                dictOfSpecialWords[word]++;
            }
            // Save the Output to a file

        }
    }
}
