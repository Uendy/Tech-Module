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
                    break;

                case "rollLeft":
                    break;

                case "rollRight":
                    break;
            }

            input = Console.ReadLine();
        }
    }

    public static void ReverseSubArray(List<string> array, List<string> inputTokens)
    {
        int startIndex = int.Parse(inputTokens[2]);
        int count = int.Parse(inputTokens[4]);

        bool validIndexs = IndexValidator(array, startIndex) && IndexValidator(array, startIndex + count);

        var newSubArray = array.GetRange(startIndex, count).Select(x => x).Reverse().ToList();

        array.RemoveRange(startIndex, count);
        array.InsertRange(startIndex, newSubArray);

        Console.WriteLine(string.Join(" ", array));
    }

    public static bool IndexValidator(List<string> array, int currentIndex)
    {
        bool isValid = currentIndex >= 0 && currentIndex < array.Count();

        return isValid;
    }
}