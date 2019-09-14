using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main(string[] args)
    {
        //Cubic is a veteran soldier from The Great Cubic Army. He has even participated in the Spherical Invasion as a Sergeant First Class.
        //As a veteran, Cubic has some personal security issues – he communicates only trough text messages and sends them in a specific encrypted way, 
        //which you must decrypt in order to understand what he is saying.

        //You will begin receiving lines of input, which will consist of random ASCII characters – Cubic’s encrypted lines.
        //After each line you will receive a number – the length of the message he sent.Cubic might send false messages, in an act to confuse his “enemies”. 
        //You must capture only the messages that follow a certain format.

        //According to that format the valid messages:
        //•	Consist of m characters, where m is the integer entered after each encrypted line.
        //•	Has only digits before itself in the encrypted line
        //•	Consists only of English alphabet letters
        //•	Has no English alphabet letters after itself in the encrypted line
        //Any message that does not follow the, specified above, rules, is invalid, and you must ignore it.

        //After you find all valid messages, you need to find their verification code.
        //Every message has its own verification code, which Cubic gives in order to verify the message.
        //Take all the digits before the message and all the digits after the message and consider them as indexes.
        //If they are valid existing indexes in the message, form a string with those indexes taking characters from the message.
        //If an index is nonexistent, put a space there. The string you form up is the verification code for the current message.

        string input = Console.ReadLine();
        while (input != "Over!")
        {
            int decrypter = int.Parse(Console.ReadLine());

            var asArray = input.ToCharArray();

            var digitArray = GetDigits(asArray);
            var letterArray = GetLetters(asArray);

            int coreIndex = CheckandFindCore(letterArray, decrypter);
            if (coreIndex == -1)
            {
                input = Console.ReadLine();
                continue;
            }

            var digitsBeforeCore = CheckDigitsBeforeCore(digitArray, coreIndex, asArray);
            if (digitsBeforeCore.Count() != coreIndex)
            {
                input = Console.ReadLine();
                continue; 
            }

            // get digits after and check if any english letters there
            var afterCore = new List<char>();
            int afterCoreIndex = coreIndex + decrypter;
            for (int index = afterCoreIndex; index < asArray.Length; index++)
            {
                afterCore.Add(asArray[index]);
            }

            bool lettersPresent = afterCore.Any(x => char.IsLetter(x));
            if (lettersPresent)
            {
                input = Console.ReadLine();
                continue;
            }
            var digitsAfterCore = new List<int>();
            for (int index = afterCoreIndex; index < asArray.Length; index++)
            {
                var currentChar = asArray[index];
                bool isDigit = char.IsDigit(currentChar);
                if (isDigit)
                {
                    int currentDigit = int.Parse(currentChar.ToString());
                    digitsAfterCore.Add(currentDigit);
                }
            }

            //get the core
            var core = asArray.ToList().GetRange(coreIndex, decrypter);
            var fullCore = string.Join("", core);

            //get both sides
            string leftSide = GetSide(digitsBeforeCore, core);

            string rightSide = GetSide(digitsAfterCore, core);

            //printing
            Console.WriteLine($"{fullCore} == {leftSide}{rightSide}");

            input = Console.ReadLine();
        }
    }

    public static string GetSide(List<int> digitsPlace, List<char> core)
    {
        var sideArray = new List<char>();
        foreach (var digit in digitsPlace)
        {
            bool insideArray = digit >= 0 && digit < core.Count();
            if (insideArray)
            {
                sideArray.Add(core[digit]);
            }
            else
            {
                sideArray.Add(' ');
            }
        }
        string side = string.Join("", sideArray);

        return side;
    }

    public static List<int> CheckDigitsBeforeCore(bool[] digitArray, int coreIndex, char[] asArray) //	Has only digits before itself in the encrypted line
    {
        var digits = new List<int>();

        for (int index = 0; index < coreIndex; index++)
        {
            var isDigit = digitArray[index] == true;
            if (isDigit)
            {
                int currentNum = int.Parse(asArray[index].ToString());
                digits.Add(currentNum);
            }
        }

        return digits;
    }

    public static int CheckandFindCore(bool[] letterArray, int decrypter) //Consist of m characters, where m is the integer entered after each encrypted line. (+ only english)
    {
        for (int index = 0; index < letterArray.Length; index++)
        {
            bool currentcheck = letterArray[index];
            if (currentcheck == true)
            {
                bool stillCorrect = true;
                for (int j = index + 1; j < index + decrypter; j++)
                {
                    bool newCurrentCheck = letterArray[index];
                    if (!newCurrentCheck)
                    {
                        stillCorrect = false;
                    }
                }

                if (stillCorrect)
                {
                    return index;
                }
            }
        }

        return -1;
    }

    public static bool[] GetLetters(char[] asArray)
    {
        var letterArray = new bool[asArray.Length];

        for (int index = 0; index < asArray.Length; index++)
        {
            char currentChar = asArray[index];
            bool isLetter = char.IsLetter(currentChar);
            if (isLetter)
            {
                letterArray[index] = true;
            }
        }

        return letterArray;
    }

    public static bool[] GetDigits(char[] asArray)
    {
        var digitsArray = new bool[asArray.Length];

        for (int index = 0; index < asArray.Length; index++)
        {
            char currentChar = asArray[index];
            bool isDigit = char.IsDigit(currentChar);
            if (isDigit)
            {
                digitsArray[index] = true;
            }
        }

        return digitsArray;
    }
}