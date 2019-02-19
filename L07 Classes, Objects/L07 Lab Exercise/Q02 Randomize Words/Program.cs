using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var words = input.Split(' ')
                .ToArray();

            var shuffledWords = new List<string>();

            var rnd = new Random();

            bool sameNumberOfWords = words.Length == shuffledWords.Count();
            while (!sameNumberOfWords)
            {
                var current = rnd.Next(0, words.Length);
                if (!shuffledWords.Contains(words[current]))
                {
                    shuffledWords.Add(words[current]);
                }

                int wordsLenth = words.Length;
                int shuffledWordLength = shuffledWords.Count();
                if (wordsLenth == shuffledWordLength)
                {
                    sameNumberOfWords = true;
                }
            }

            foreach (var word in shuffledWords)
            {
                Console.WriteLine(word);
            }

        }
    }
}
