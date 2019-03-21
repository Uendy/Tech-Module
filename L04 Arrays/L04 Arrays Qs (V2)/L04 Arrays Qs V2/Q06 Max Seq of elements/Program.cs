using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that finds the longest sequence of equal elements in an array of integers.
        //If several longest sequences exist, print the leftmost one.

        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var element = 0;
        var currentSeq = 1;
        var maxSeq = 1;

        for (int index = 0; index < array.Length - 1; index++)
        {
            var currentNum = array[index];
            var nextNum = array[index + 1];

            bool sequence = currentNum == nextNum;
            if (sequence == true)
            {
                currentSeq++;
                if (index == array.Length - 2) // last element, so check if newMax
                {
                    bool newMax = currentSeq > maxSeq;
                    if (newMax == true)
                    {
                        element = currentNum;
                        maxSeq = currentSeq;
                    }
                }
            }
            else
            {
                bool newMax = currentSeq > maxSeq;
                if (newMax == true)
                {
                    element = currentNum;
                    maxSeq = currentSeq;
                }

                currentSeq = 1;
            }
        }

        var outPutArray = new int[maxSeq];
        for (int index = 0; index < maxSeq; index++)
        {
            outPutArray[index] = element;
        }

        var outPut = string.Join(" ", outPutArray);
        Console.WriteLine(outPut);
    }
}