using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //Write a program that finds the longest increasing subsequence in an array of integers. 
        //The longest increasing subsequence is a portion of the array (subsequence),
        //that is strongly increasing and has the longest possible length.
        //If several such subsequences exist, find the left most of them.

        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var startOfLongestSeq = 0;
        var currentLength = 1;
        var longestLength = 1;

        for (int index = 0; index < array.Length - 1; index++)
        {
            var currentNum = array[index];
            var nextNum = array[index + 1];

            bool sequence = currentNum < nextNum;
            if (sequence == true)
            {
                currentLength++;
            }
            else
            {
                bool newMax = currentLength > longestLength;
                if (newMax == true)
                {
                    startOfLongestSeq = index - currentLength;
                    longestLength = currentLength;
                }
                currentLength = 1;
            }
        }

        var outPutArray = new int[longestLength];
        int arrayIndex = 0;
        for (int i = startOfLongestSeq; i < startOfLongestSeq + longestLength; i++)
        {
            outPutArray[arrayIndex] = array[i];
            arrayIndex++;
        }

        string outPut = string.Join(" ", outPutArray);
        Console.WriteLine(outPut);
    }
}