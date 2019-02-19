using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Strings_and_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();

            string combinationOfWords = string.Format(firstWord + " " + secondWord);

           // Console.WriteLine(combinationOfWords);

            // or my way 

             Console.WriteLine("{0} {1}",firstWord,secondWord);
        }
    }
}
