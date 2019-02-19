using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Randomize_Words_p2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');

            Random rnd = new Random();
            for (int pos1 = 0; pos1 < words.Length; pos1++)
            {
                int pos2 = rnd.Next(words.Length);
                string currentWord = words[pos1];
                string tempWord = words[pos2];
                words[pos1] = tempWord;
                words[pos2] = currentWord;
            }
            Console.WriteLine(string.Join("\r\n", words));

        }
    }
}
