using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Punctuation_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var listOfPunctuation = new List<char>();
            foreach (var letter in input.ToCharArray())
            {
                bool punctuation = letter == ',' || letter == '.' || letter == '!' || letter == '?' || letter == ':';
                if (punctuation == true)
                {
                    listOfPunctuation.Add(letter);
                }
            }

            foreach (var symbol in listOfPunctuation)
            {
                Console.Write($"{symbol}, ");
            }
        }
    }
}
