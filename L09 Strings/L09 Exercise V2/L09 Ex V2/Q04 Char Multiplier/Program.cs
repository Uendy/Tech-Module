using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Create a method that takes two strings as arguments
        //returning the sum of their character codes multiplied (multiply str1.charAt (0) with str2.charAt (0) add to the total sum).
        //Then continue with the next two characters. 
        //If one of the strings is longer than the other, add the remaining character codes to the total sum without multiplication.

        var input = Console.ReadLine().Split(' ').ToArray().OrderByDescending(x => x.Length).ToArray();
        var firstString = input[0];
        var secondString = input[1];

        Console.WriteLine(CharMultiplier(firstString, secondString));

    }

    static int CharMultiplier(string firstString, string secondString)
    {
        int sum = 0;

        var firstStringAsCharArray = firstString.ToCharArray();
        var secondStringAsCharArray = secondString.ToCharArray();

        for (int index = 0; index < firstString.Length; index++)
        {
            bool passedSecondString = index >= secondString.Count();
            if (!passedSecondString)
            {
                sum += firstStringAsCharArray[index] * secondStringAsCharArray[index];
            }
            else
            {
                sum += firstStringAsCharArray[index];
            }
        }


        return sum;
    }
}