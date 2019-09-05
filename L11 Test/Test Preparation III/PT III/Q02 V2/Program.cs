using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var array = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string input = Console.ReadLine();
        while (input != "end")
        {
            var inputTokens = input.Split(' ').ToList();

            string command = inputTokens[0];

            switch (command)
            {
                case "reverse":
                    ReverseSubArray(array, inputTokens);
                    break;

                case "sort":
                    SortSubArray(array, inputTokens);
                    break;

                case "rollLeft":
                    CommandRollLeft(array, inputTokens);
                    break;

                case "rollRight":
                    break;
            }

            input = Console.ReadLine();
        }

        string outPut = string.Join(", ", array);
        Console.WriteLine($"[{outPut}]");
    }

    public static void CommandRollLeft(List<string> array, List<string> inputTokens)
    {
        int shiftBy = int.Parse(inputTokens[1]);

        for (int index = array.Count() - 1; index >= 0; index--)
        {
            var currentString = array[index];


        }
    }

    public static void SortSubArray(List<string> array, List<string> inputTokens)
    {
        int startIndex = int.Parse(inputTokens[2]);
        int count = int.Parse(inputTokens[4]);

        bool validIndexs = IndexValidator(array, startIndex) && IndexValidator(array, startIndex + count);
        if (!validIndexs)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        var newSubArray = array.GetRange(startIndex, count).Select(x => x).OrderBy(x => x).ToList();

        array.RemoveRange(startIndex, count);
        array.InsertRange(startIndex, newSubArray);

        Console.WriteLine(string.Join(" ", array));
    }

    public static void ReverseSubArray(List<string> array, List<string> inputTokens)
    {
        int startIndex = int.Parse(inputTokens[2]);
        int count = int.Parse(inputTokens[4]);

        bool validIndexs = IndexValidator(array, startIndex) && IndexValidator(array, startIndex + count);
        if (!validIndexs)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        var newSubArray = array.GetRange(startIndex, count).Select(x => x).Reverse().ToList();

        array.RemoveRange(startIndex, count);
        array.InsertRange(startIndex, newSubArray);
    }

    public static bool IndexValidator(List<string> array, int currentIndex)
    {
        bool isValid = currentIndex >= 0 && currentIndex < array.Count();

        return isValid;
    }
}