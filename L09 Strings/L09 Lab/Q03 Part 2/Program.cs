using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = "Test";
            var sb = new StringBuilder(word);
            sb[0] = 't';
            Console.WriteLine(sb.ToString());

            string[] banWords = Console.ReadLine()
             .Split(' ', ',');

            string text = Console.ReadLine();
            foreach (var banWord in banWords)
            {
                // if (text.Contains(banWord))
                //{
                text = text.Replace(banWord, new string('*', banWord.Length));
                //}
            }
            Console.WriteLine(text);

        }
    }
}
