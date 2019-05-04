using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program, which reads a string and skips through it, extracting a hidden message. 
        //The algorithm you have to implement is as follows:

        //Let’s take the string “skipTest_String044170” as an example.
        //Take every digit from the string and store it somewhere.
        //After that, remove all the digits from the string.
        //After this operation, you should have two lists of items: the numbers list and the non-numbers list:
        //•	Numbers list: [0, 4, 4, 1, 7, 0]
        //•	Non-numbers: [s, k, i, p, T, e, s, t, _, S, t, r, i, n, g]

        //After that, take every digit in the numbers list and split it up into a take list and a skip list, depending on whether the digit is in an even or an odd index:
        //•	Numbers list: [0, 4, 4, 1, 7, 0]
        //•	Take list: [0, 4, 7]
        //•	Skip list: [4, 1, 0]

        //Afterwards, iterate over both of the lists and skip { skipCount }
        //characters from the non-numbers list, then take {takeCount} characters and store it in a result string.
        //Note that the skipped characters are summed up as they go.T
        //he process would look like this on the aforementioned non-numbers list:
        //1.	Skip 4 characters (total 0), take 0 characters  “skipTest_String”  Taken: “”  Result: “”
        //2.	Skip 1 characters(total 4), take 4 characters  “skipTest_String”  Taken: “Test”  Result: “Test”
        //3.	Skip 0 characters(total 9), take 7 characters  “skipTest_String”  Taken: “String”  Result: “TestString”
        //After that, just print the result string on the console.

        var message = Console.ReadLine().ToCharArray();
        var numberList = new List<int>();
        var otherList = new List<char>();

        //splitting up message into digits and others
        foreach (var charecter in message)
        {
            string currentChar = charecter.ToString();
            bool successfullyParse = int.TryParse(currentChar, out int currentNum);
            if (successfullyParse)
            {
                numberList.Add(currentNum);
            }
            else
            {
                otherList.Add(charecter);
            }
        }

        //splitting numbersList into take(even index) and skip(odd index)
        var listToTake = new List<int>();
        var listToSkip = new List<int>();
        for (int index = 0; index < numberList.Count(); index++)
        {
            bool isEven = index % 2 == 0;
            if (isEven)
            {
                listToTake.Add(numberList[index]);
            }
            else //odd -> Skip
            {
                listToSkip.Add(numberList[index]);
            }
        }


        //iterate through otherList with Skip and Take
        string outPut = string.Empty;
        for (int index = 0; index < listToSkip.Count(); index++) // what if skip.Count() != take.Count()?
        {
            string result = new string(otherList.Take(listToTake[index]).ToArray()); 
            if (otherList.Count() > listToSkip[index] + listToTake[index]) 
            {
                otherList.RemoveRange(0, listToSkip[index] + listToTake[index]); // removing all skipped and taken
            }
            outPut += result;
        }

        Console.WriteLine(outPut);
    }
}