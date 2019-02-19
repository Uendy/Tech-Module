using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Byte_Flip
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToList();

            //weeds out all inputs longer or shorter than 2 chars
            var listOfOnlyTwoCharLong = new List<string>(); 
            foreach (var item in input)
            {
                bool notTwoCharsLong = item.Length != 2;
                if (notTwoCharsLong == false)
                {
                    listOfOnlyTwoCharLong.Add(item);
                }
            }

            //flips the chars around in each item in listOfOnlyTwoCharLong
            var newListOfReversedChars = new List<string>();
            foreach (var item in listOfOnlyTwoCharLong)
            {
                var flip = item.ToArray().Reverse();
                string turnedAround = "";
                foreach (var symbol in flip)
                {
                    turnedAround += symbol;
                }
                newListOfReversedChars.Add(turnedAround);

            }
            newListOfReversedChars.Reverse(); // turn the whole order around

            //converts from hexadec to ASCII int code
            var finalListOfASCIICodes = new List<int>();
            foreach (var item in newListOfReversedChars)
            {
                int currentASCIICode = Convert.ToInt32(item, 16);
                finalListOfASCIICodes.Add(currentASCIICode);
            }

            string finalOutput = "";
            // from ASCII int code to char
            foreach (var ASCIICode in finalListOfASCIICodes)
            {
                char currentChar = (char)ASCIICode;
                finalOutput += currentChar;
            }
            Console.WriteLine(finalOutput);
        }
    }
}
