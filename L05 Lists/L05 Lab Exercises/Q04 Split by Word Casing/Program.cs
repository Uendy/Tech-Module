using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> stringFormat = input.Split(' ', ',', '.', ';', ':', '!', '(', ')', '"', '\\', '/', '[', ']', '\'' ).ToList();

            List <string> lowerCase = new List<string>();
            List <string> upperCase = new List<string>();
            List <string> mixedCase = new List<string>();

            for (int index = 0; index < stringFormat.Count; index++)
            {
                string currentString = stringFormat[index];

                bool upper = false;
                bool lower = false;

                for (int currentStringIndex = 0; currentStringIndex < currentString.Length; currentStringIndex++)
                {
                    bool lowerCaseCheck = currentString[currentStringIndex] >= 97 && currentString[currentStringIndex] <= 122;
                    bool upperCaseCheck = currentString[currentStringIndex] >= 65 && currentString[currentStringIndex] <= 90;
                    bool mixedCaseCheck = currentString[currentStringIndex] < 65 || currentString[currentStringIndex] > 90 && currentString[currentStringIndex] < 97;

                    if (lowerCaseCheck == true)
                    {
                        lower = true;
                    }
                    else if (upperCaseCheck == true)
                    {
                        upper = true;
                    }
                    else if (mixedCaseCheck == true)
                    {
                        lower = true;
                        upper = true;
                    }
                }

                if (lower == true && upper == true)
                {
                    mixedCase.Add(stringFormat[index]);
                }
                else if (lower == true)
                {
                    lowerCase.Add(stringFormat[index]);
                }
                else if (upper == true)
                {
                    upperCase.Add(stringFormat[index]);
                }
            }
             
            Console.WriteLine("Lower-case: " + String.Join(", ",lowerCase));
            Console.WriteLine("Mixed-case: " + String.Join(", ",mixedCase));
            Console.WriteLine("Upper-case: " + String.Join(", ",upperCase));
        }
    }
}
