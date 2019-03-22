using System;
using System.Collections.Generic;
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

        var listOfCurrentSeq = new List<int>();
        //var currentSeqLength = listOfCurrentSeq.Count();

        var listOfMaxSeq = new List<int>();
        //var maxSeqLength = listOfMaxSeq.Count();

        int currentLength = 0;

        for (int index = 0; index < array.Length - 1; index++)
        {
            var currentNum = array[index];
            var nextNum = array[index + 1];

            bool sequence = currentNum < nextNum;
            if (sequence == true)
            {
                listOfCurrentSeq.Add(currentNum);
                currentLength++;

                bool lastElement = index == array.Length - 2;
                if (lastElement == true)
                {
                    var maxSeqLength = listOfMaxSeq.Count();
                    bool newMax = currentLength > maxSeqLength;
                    if (newMax == true)
                    {
                        listOfMaxSeq.Clear();
                        listOfMaxSeq.AddRange(listOfCurrentSeq);
                        listOfMaxSeq.Add(nextNum); // since last in Seq
                        listOfCurrentSeq.Clear();
                    }
                }
            }
            else
            {
                var maxSeqLength = listOfMaxSeq.Count();
                bool newMax = currentLength > maxSeqLength;
                if (newMax == true)
                {
                    listOfMaxSeq.Clear();
                    listOfMaxSeq.AddRange(listOfCurrentSeq);
                    listOfMaxSeq.Add(currentNum); // since last in Seq
                    listOfCurrentSeq.Clear();
                }
                currentLength = 0;
            }
        }

        string outPut = string.Join(" ", listOfMaxSeq);
        Console.WriteLine(outPut);
    }
}