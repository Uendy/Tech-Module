using System;
using System.Collections.Generic;
using System.Linq;

namespace Q05_Magic_Exchange_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            //case sensitive?
            var input = Console.ReadLine().Split(' ').ToArray();

            var firstString = input[0];
            var secondString = input[1];

            Console.WriteLine(MagicExchange(firstString, secondString).ToString().ToLower());

        }

        static bool MagicExchange(string firstString, string secondString)
        {
            bool exchangable = false;

            var firstStringAsCharArray = firstString.ToCharArray();
            var secondStringAsCharArray = secondString.ToCharArray();

            var firstWordDict = new Dictionary<char, int>();
            foreach (var letter in firstStringAsCharArray)
            {
                if (!firstWordDict.ContainsKey(letter))
                {
                    firstWordDict[letter] = 1;
                }
                else
                {
                    firstWordDict[letter]++;
                }
            }
            firstWordDict = firstWordDict.OrderByDescending(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            var secondWordDict = new Dictionary<char, int>();
            foreach (var letter in secondStringAsCharArray)
            {
                if (!secondWordDict.ContainsKey(letter))
                {
                    secondWordDict[letter] = 1;
                }
                else
                {
                    secondWordDict[letter]++;
                }
            }
            secondWordDict = secondWordDict.OrderByDescending(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            if (secondWordDict.Keys.Count == firstWordDict.Keys.Count)
            {
                exchangable = true;
            }

            return exchangable;
        }
    }
}
