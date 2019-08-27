using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main(string[] args)
    {
        // Question is in previous version Q03 Anonymous Vox (a.k.a Q03 V1)

        string input = Console.ReadLine();
        var values = Console.ReadLine().Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var placeHoldersAndValues = new List<string>();

        var inputAsArray = input.ToCharArray().ToList();
        int inputCount = inputAsArray.Count();

        for (int firstIndex = 0; firstIndex < inputCount - 2; firstIndex++)
        {
            char firstChar = inputAsArray[firstIndex];
            bool isLetter = IsLetter(firstChar);
            if (isLetter)
            {
                for (int secondIndex = inputCount - 1; secondIndex > firstIndex; secondIndex--)
                {
                    char secondChar = inputAsArray[secondIndex];
                    bool alsoLetter = IsLetter(secondChar);
                    if (alsoLetter)
                    {
                        bool equalChars = firstChar == secondChar;
                        if (equalChars)
                        {

                            int indexAdded = 0; // Gotta check if they are letters
                            char newFirst = inputAsArray[firstIndex + indexAdded];
                            char newSecond = inputAsArray[secondIndex + indexAdded];

                            while (newFirst == newSecond)
                            {
                                indexAdded++;

                                bool indexOver = inputCount == secondIndex + indexAdded;
                                if (indexOver)
                                {
                                    break; // here stop it?
                                }
                                newFirst = inputAsArray[firstIndex + indexAdded];
                                newSecond = inputAsArray[secondIndex + indexAdded];

                                bool bothAreLetters = IsLetter(newFirst) && IsLetter(newSecond);
                                if (!bothAreLetters)
                                {
                                    break;
                                }

                            }

                            bool pattern = indexAdded > 0;
                            if (pattern)  // extract the new substring, add it to list, replace it in previous input and update everything for next cycle
                            {
                                var placeHolderArray = inputAsArray.GetRange(firstIndex, indexAdded);
                                string placeHolder = string.Join("", placeHolderArray);

                                string currentValue = values[0];

                                string currentSubstring = $"{placeHolder}{currentValue}{placeHolder}";
                                placeHoldersAndValues.Add(currentSubstring);

                                int countToRemove = secondIndex + indexAdded - firstIndex; 

                                var removeThisRange = inputAsArray.GetRange(firstIndex, countToRemove);
                                string removeString = string.Join("", removeThisRange);

                                string replaced = input.Replace(removeString, "{?}");
                                input = replaced;
                                inputAsArray = input.ToCharArray().ToList();

                                //check if last one
                                values.RemoveAt(0);
                                bool noMoreValues = values.Count() == 0;
                                if (noMoreValues)
                                {
                                    ReplacePrintAndEnd(input, placeHoldersAndValues);
                                }

                                //restart indexs and count
                                inputCount = input.Count();
                                firstIndex = 0;
                                firstChar = inputAsArray[firstIndex];
                                secondIndex = inputCount - 1;
                            }
                        }

                    }
                }
            }
        }

        ReplacePrintAndEnd(input, placeHoldersAndValues);
    }

    public static bool IsLetter(char currentChar)
    {
        bool isLetter = char.IsLetter(currentChar);
        return isLetter;
    }

    public static void ReplacePrintAndEnd(string input, List<string> placeHolderAndValues)
    {
        foreach (var holderAndValue in placeHolderAndValues)
        {
            input = ReplaceFirst(input, holderAndValue);
        }

        Console.WriteLine(input);
        Environment.Exit(0);
    }

    public static string ReplaceFirst(string input, string replace)
    {
        string search = "{?}";

        int pos = input.IndexOf(search);
        if (pos < 0)
        {
            return input;
        }
        return input.Substring(0, pos) + replace + input.Substring(pos + search.Length);
    }
}