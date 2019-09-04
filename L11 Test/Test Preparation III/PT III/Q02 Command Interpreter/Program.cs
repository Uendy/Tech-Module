using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //You will be given a series of strings on a single line, separated by one or more whitespaces.
        //These represent the collection you’ll be working with.

        //On the next input lines, until you receive the command "end", you’ll receive a series of commands in one of the following formats:
        //•	"reverse from [start] count [count]" – this instructs you to reverse a portion of the array – just[count] elements starting at index[start];
        //•	"sort from [start] count [count]" – this instructs you to sort a portion of the array - [count] elements starting at index[start];
        //•	"rollLeft [count] times" – this instructs you to move all elements in the array to the left[count] times.
        //On each roll, the first element is placed at the end of the array;
        //•	"rollRight [count] times" – this instructs you to move all elements in the array to the right[count] times.
        //On each roll, the last element is placed at the beginning of the array;

        //If any of the provided indices or counts is invalid(non - existent index or negative count), 
        //you should print a message on the console "Invalid input parameters." and keep the collection unchanged.

        //After you’re done, print the resulting array in the following format: "[arr0, arr1, …, arrN-1]".
        //The examples should help you understand the task better.
        #endregion

        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        string commandLine = Console.ReadLine().ToLower();

        while (commandLine != "end")
        {
            var commandTokens = commandLine.Split(' ').ToArray();

            var command = commandTokens[0];

            switch (command)
            {
                case "reverse":
                    ReverseSubArray(array, commandTokens);
                    break;

                case "sort":

                    break;

                case "rollLeft":
                    
                    break;

                case "rollRight":

                    break;
            }

            commandLine = Console.ReadLine();
        }

        string outPut = string.Join(" ", array);
        Console.WriteLine(outPut);
    }

    public static void ReverseSubArray(List<int> array, string[] commandTokens)
    {
        int startIndex = int.Parse(commandTokens[2]);
        int count = int.Parse(commandTokens[4]);

        bool validIndex = IndexValidator(array, startIndex) && IndexValidator(array, startIndex + count);
        if (!validIndex)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        var newSubArray = array.GetRange(startIndex, count).Select(x => x).Reverse().ToList();

        array.RemoveRange(startIndex, count);
        array.InsertRange(startIndex, newSubArray);
    }

    public static bool IndexValidator(List<int> array, int checkedIndex)
    {
        bool validIndex = checkedIndex >= 0 && checkedIndex < array.Count();

        return validIndex;
    }
}