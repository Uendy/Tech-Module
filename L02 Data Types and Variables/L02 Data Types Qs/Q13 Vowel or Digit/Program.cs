using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q13_Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());

            bool checkIfDigit = symbol >= 48 && symbol <= 57;
            bool checkIfVowel = (symbol == 97 || symbol == 101 || symbol == 105 || symbol == 111 || symbol == 117);

            if (checkIfDigit)
            {
                Console.WriteLine("digit");
            }
            else if (checkIfVowel)
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
