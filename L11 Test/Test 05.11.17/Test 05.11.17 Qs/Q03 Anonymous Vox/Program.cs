using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        #region
        //You will receive an input line containing a single string – the encoded text.
        //Then, on the next line you will receive several values in the following format: “{value1}{value2}{value3}...”.

        //You must find the encoded placeholders in the text and REPLACE each one of them with the value that corresponds to its index. 
        //Example: placeholder1 – value1, placeholder2 – value2 etc. 
        //There may be more values than placeholders or more placeholders than values.

        //The placeholders consist of 3 blocks { start} { placeholder} { end}. 
        //The start should consist only of English alphabet letters.
        //The placeholder may contain ANY ASCII character.The end should be EXACTLY EQUAL to the start.
        //The idea is that you have to find the placeholders, and REPLACE their placeholder block with the value at that index.

        //Example Placeholders: “a.....a”, “b!d!b”, “asdxxxxxasd”, “peshogoshopesho”...
        //You must ALWAYS match the placeholder with the LONGEST start and the RIGHTMOST end. 
        //For example if you have “asddvdasd” you should NOT match “dvd” as a placeholder, you should match “asddvdasd”.
        //At the end you must print the result text, after you’ve replaced the values.
        #endregion

        string input = Console.ReadLine();
        string values = Console.ReadLine();

        var listOfValues = values.Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var inputAsArray = input.ToCharArray().ToList();
        int arrayCount = inputAsArray.Count();


        // check if there is a problem manipulating the array/arrayCount inside the forcycle while using it
        // other problem if there are just double letters ex: hello -> ll ?

        //change 2nd loop to be reversed so you get the biggest and rightmost one
        for (int firstIndex = 0; firstIndex < arrayCount - 3; firstIndex++)
        {
            char firstChar = inputAsArray[firstIndex];
            bool isLetter = char.IsLetter(firstChar);
            if (isLetter)
            {
                for (int secondIndex = arrayCount - 1; secondIndex > firstIndex; secondIndex--)
                {

                    char secondChar = inputAsArray[secondIndex];
                    bool secondIsLetter = char.IsLetter(secondChar);

                    bool equalChars = firstChar == secondChar;
                    if (equalChars)
                    {
                        int indexAdded = 0;
                        var sb = new StringBuilder();
                        while (inputAsArray[firstIndex + indexAdded] == inputAsArray[secondIndex + indexAdded])
                        {
                            sb.Append(inputAsArray[firstIndex + indexAdded]);
                            indexAdded++;

                            bool indexOver = arrayCount == secondIndex + indexAdded;
                            if (indexOver)
                            {
                                break;
                            }
                        }

                        bool pattern = indexAdded > 0;
                        if (pattern)
                        {
                            var placeHolder = sb.ToString().ToCharArray().ToList();

                            //find the start of the placeHolder and how much to remove
                            int startIndex = firstIndex + indexAdded;
                            int valueLength = secondIndex - (indexAdded);

                            inputAsArray.RemoveRange(startIndex, valueLength);
                            inputAsArray.InsertRange(startIndex, listOfValues[0]);

                            listOfValues.RemoveAt(0);

                            // change firstIndex so you dont cycle through list of values all on first placeholder
                            firstIndex = secondIndex + indexAdded;

                            bool noMoreValues = listOfValues.Count() == 0; //one way to end it, no more values
                            if (noMoreValues)
                            {
                                PrintAndEnd(inputAsArray);
                            }
                        }
                    }
                }
            }
        }

        PrintAndEnd(inputAsArray); // other way to end it, no more placeholders
    }

    public static void PrintAndEnd(List<char> inputAsArray)
    {
        string outPut = string.Join("", inputAsArray);
        Console.WriteLine(outPut);
        Environment.Exit(0);
    }
}