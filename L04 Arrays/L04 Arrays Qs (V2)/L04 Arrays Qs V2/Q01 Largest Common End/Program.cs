using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read two arrays of words and find the length of the largest common end (left or right).
        var firstArray = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        var secondArray = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        bool commonAtStart = firstArray[0] == secondArray[0];
        if (commonAtStart == true)
        {
            CommonCounter(firstArray, secondArray);
        }
        else //common at end
        {
            firstArray = firstArray.Reverse().ToArray();
            secondArray = secondArray.Reverse().ToArray();
            CommonCounter(firstArray, secondArray);
        }
    }

    public static void CommonCounter(string[] firstArray, string[] secondArray)
    {
        int commonCounter = 0;
        for (int index = 0; index < firstArray.Length || index < secondArray.Length; index++)
        {
            if (firstArray[index] == secondArray[index])
            {
                commonCounter++;
            }
            else
            {
                Console.WriteLine(commonCounter);
                Environment.Exit(0);
            }
        }
    }
}