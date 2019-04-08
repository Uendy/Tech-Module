using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You are going to receive two lists with numbers.
        //Create a result list, which contains the numbers from both of the lists.
        //The first element should be from the first list, the second from the second list and so on. 
        //If the length of the two lists are not equal, just add the remaining elements at the end of the list.

        var firstList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var secondList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        var outPutList = new List<int>();
        var shorterCountList = Math.Min(firstList.Count(), secondList.Count());

        for (int index = 0; index < shorterCountList; index++)
        {
            outPutList.Add(firstList[index]);
            outPutList.Add(secondList[index]);
        }

        if (firstList.Count() > shorterCountList)
        {
            outPutList = AddRemainingItems(outPutList, firstList, shorterCountList);
        }
        else if (secondList.Count() > shorterCountList)
        {
            outPutList = AddRemainingItems(outPutList, secondList, shorterCountList);
        }

        string outPut = string.Join(" ", outPutList);
        Console.WriteLine(outPut);
    }

    public static List<int> AddRemainingItems(List<int> outPutList, List<int> firstList, int shorterCountList)
    {
        for (int index = shorterCountList; index < firstList.Count(); index++)
        {
            outPutList.Add(firstList[index]);
        }
        return outPutList;
    }
}