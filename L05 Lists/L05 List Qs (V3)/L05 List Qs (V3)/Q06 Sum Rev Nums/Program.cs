using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //Write a program that reads sequence of numbers, reverses their digits, and prints their sum.

        // Example:
        //   Input         Output             Comment
        // 123 234 12       774         321 + 432 + 21 = 774
        #endregion

        // Reading input:
        var list = Console.ReadLine().Split(' ').ToList();

        var revList = list.ToList();

        // Cycle and reverse
        for (int index = 0; index < list.Count(); index++)
        {
            string current = list[index];
            var reverse = reverseNum(current);
            revList[index] = reverse;
        }

        // Sum and Print
        int sum = revList.Select(int.Parse).Sum();
        Console.WriteLine(sum);
    }

    public static string reverseNum(string current)
    {
        var rev = current.ToCharArray().Reverse();
        string reversed = string.Join("", rev);
        return reversed;
    }
}