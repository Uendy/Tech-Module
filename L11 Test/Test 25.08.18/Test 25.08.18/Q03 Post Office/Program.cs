using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //You read a single line of ASCII symbols, and the message is somewhere inside it, you must find it.

        //The input consists of three parts separated with "|" like this:
        //"{firstPart}|{secondPart}|{thirdPart}"

        //Each word starts with capital letter and has a fixed length, you can find those in each different part of the input.

        //The first part carries the capital letters for each word inside the message.You need to find those capital letters 1 or more from A to Z.
        //The capital letters should be surrounded from the both sides with any of the following symbols – "#, $, %, *, &".
        //And those symbols should match on the both sides.This means that $AOTP$ - is a valid pattern for the capital letters. 
        //$AKTP % - is invalid since the symbols do not match.

        //The second part of the data contains the starting letter ASCII code and words length / between 1 – 20 charactes /, in the following format: "{asciiCode}:{length}".
        //For example, "67:05" – means that '67' - ascii code equal to the capital letter "C", represents a word starting with "C" with following 5 characters: like "Carrot".
        //The ascii code should be a capital letter equal to a letter from the first part.Word's length should be exactly 2 digits.
        //Length less than 10 will always have a padding zero, you don't need to check that.

        //The third part of the message are words separated by spaces.
        //Those words have to start with Capital letter[A…Z] equal to the ascii code and have exactly the length for each capital letter you have found in the second part.
        //Those words can contain any ASCII symbol without spaces.
        #endregion

        string input = Console.ReadLine();
        var parts = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        //The first part carries the capital letters for each word inside the message.You need to find those capital letters 1 or more from A to Z.
        //The capital letters should be surrounded from the both sides with any of the following symbols – "#, $, %, *, &".
        //And those symbols should match on the both sides.This means that $AOTP$ - is a valid pattern for the capital letters. 
        //$AKTP % - is invalid since the symbols do not match.
        var firstPart = parts[0];
        var firstLetters = new List<char>();

        var specialSymbols = new char[] { '#', '$', '*', '&' };
        foreach (var symbol in specialSymbols)
        {
            var indexOfSymbol = firstPart.IndexOf(symbol);
            var indexOfSecondSymbol = firstPart.IndexOf(symbol, indexOfSymbol + 1); // could crash if symbol is on last index

            bool notEnoughSymbols = indexOfSymbol == -1 || indexOfSecondSymbol == -1;
            if (notEnoughSymbols)
            {
                continue;
            }

            var asArray = firstPart.ToCharArray().ToList();
            int lengthOfString = indexOfSecondSymbol - indexOfSymbol;
            var range = asArray.GetRange(indexOfSymbol + 1, lengthOfString - 1); // + 1 and -1 are to not count the special symbols in the range

            bool onlyLetters = true;
            foreach (var checkedSymbol in range)
            {
                bool isLetter = char.IsLetter(checkedSymbol);
                if (!isLetter)
                {
                    onlyLetters = false;
                    break;
                }
            }

            if (!onlyLetters)
            {
                continue;
            }

            firstLetters.InsertRange(0, range);
            break;
        }

        //The second part of the data contains the starting letter ASCII code and words length / between 1 – 20 charactes /, in the following format: "{asciiCode}:{length}".
        //For example, "67:05" – means that '67' - ascii code equal to the capital letter "C", represents a word starting with "C" with following 5 characters: like "Carrot".
        //The ascii code should be a capital letter equal to a letter from the first part.Word's length should be exactly 2 digits.
        //Length less than 10 will always have a padding zero, you don't need to check that.
        var secondPart = parts[1];

        var secAsArray = secondPart.ToList();

        //var capitalAndLength = new Dictionary<char, int>(); // could have 2 with the same starting letter (key)
        var capitalAndLength = new List<int[]>();
        int indexOfColon = secAsArray.IndexOf(':');
        while (indexOfColon != -1)
        {
            var dataRange = secAsArray.GetRange(indexOfColon - 2, 5); // find the : and check if they have digits on both sides

            dataRange.Remove(':');

            bool isValid = true;
            foreach (var digit in dataRange)
            {
                bool isDigit = char.IsDigit(digit);
                if (!isDigit) // check next ':'
                {
                    isValid = false;
                }
            }

            if (!isValid)
            {
                indexOfColon = secAsArray.IndexOf(':', indexOfColon + 1);
                continue;
            }

            //getting both sides, parsing them and adding them to the list 
            var leftSide = new string(dataRange.Take(2).ToArray()).ToString();
            int codeASCII = int.Parse(leftSide);

            char capital = (char)int.Parse(leftSide);
            bool presentInFirstLetters = firstLetters.Contains(capital);
            if (!presentInFirstLetters)
            {
                indexOfColon = secAsArray.IndexOf(':', indexOfColon + 1);
                continue;
            }

            var rightSide = new string(dataRange.Skip(2).ToArray()).ToString();
            int wordLength = int.Parse(rightSide);
            bool rightLength = wordLength >= 1 && wordLength <= 20;
            if (!rightLength)
            {
                indexOfColon = secAsArray.IndexOf(':', indexOfColon + 1);
                continue;
            }

            var currentData = new int[] { codeASCII, wordLength };
            capitalAndLength.Add(currentData);

            indexOfColon = secAsArray.IndexOf(':', indexOfColon + 1);
        }

        var distinctData = capitalAndLength.Distinct().ToList();
        //Part 3
        //The third part of the message are words separated by spaces.
        //Those words have to start with Capital letter[A…Z] equal to the ascii code and have exactly the length for each capital letter you have found in the second part.
        //Those words can contain any ASCII symbol without spaces.

        var thirdPart = parts[2];

        var thirdPartArray = thirdPart.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        var outPut = new List<string>();

        foreach (var cap in firstLetters)
        {

            foreach (var currentData in capitalAndLength)
            {
                int capitalAsInt = currentData[0];
                char capital = (char)capitalAsInt;
                bool capitalMatch = cap == capital;
                if (capitalMatch)
                {
                    var size = currentData[1];
                    var matches = thirdPartArray.Where(x => x.First() == capital).ToList(); // +1 as size dosent account for the capital letter infront

                    foreach (var word in matches)
                    {
                        bool rightLength = word.Length == size + 1; // +1 as size dosent account for the capital letter infront
                        if (rightLength)
                        {
                            outPut.Add(word);
                            break;
                        }
                    }
                }
            }
        }

        var result = outPut.Distinct().ToList();
        foreach (var word in result)
        {
            Console.WriteLine(word);
        }

    }
}