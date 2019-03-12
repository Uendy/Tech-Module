using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that finds the longest sequence of equal elements in an array of integers.
        //If several longest sequences exist, print the leftmost one.

        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var longestLength = 1;
        int digitOfSequence = int.MinValue;

        for (int index = 0; index < array.Length; index++)
        {
            var currentNum = array[index];
            int innerIndex = index + 1;
            int currentConsecutiveCount = 1;

            while (innerIndex < array.Length && currentNum == array[innerIndex])
            {
                currentConsecutiveCount++;

                bool newLongestSeq = longestLength < currentConsecutiveCount;
                if(newLongestSeq == true)
                {
                    digitOfSequence = currentNum;
                    longestLength = currentConsecutiveCount;
                }

                innerIndex++;
            }
        }

        string outPut = string.Empty;
        for (int i = 0; i < longestLength; i++)
        {
            outPut += digitOfSequence.ToString() + ' ';
        }

        Console.WriteLine(outPut);
    }
}