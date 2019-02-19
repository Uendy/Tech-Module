using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayOfWords = Console.ReadLine().Split(new char[] { ' ', ',','.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();

            var listOfPalindromes = new List<string>();

            foreach (var word in arrayOfWords)
            {
                int wordLength = word.Length;

                var wordAsCharArray = word.ToCharArray();

                var firstHalfAsArray = wordAsCharArray.Take(wordLength / 2);//.ToArray(); // It returns IEnummerable<char>
                var firstHalf = string.Concat(firstHalfAsArray);
                var secondHalfAsArray = wordAsCharArray.Reverse().Take(wordLength / 2);//.ToArray();
                var secondHalf = string.Concat(secondHalfAsArray);

                if (firstHalf.Equals(secondHalf))
                {
                    listOfPalindromes.Add(word);
                }
         
            }

            Console.WriteLine(string.Join(", ",listOfPalindromes.OrderBy(x => x)));

        }
    }
}
