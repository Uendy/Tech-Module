using System;
public class Program
{
    public static void Main()
    {
        //A palindrome is a number which reads the same backward as forward, such as 323 or 1001.
        //Write a program which reads a positive integer numbers until you receive "End",
        //for each number print whether the number is palindrome or not.

        string input = Console.ReadLine();
        while (input != "END") 
        {
            Console.WriteLine(CheckIfPalendrome(input).ToString().ToLower());

            input = Console.ReadLine();
        } 
    }

    public static bool CheckIfPalendrome(string input)
    {
        bool isPalendrome = false;

        if (input.Length == 1)
        {
            return isPalendrome = true;
        }
        else  // odd length
        {
            var inputAsCharArr = input.ToCharArray();

            var firstHalf = string.Empty;
            for (int index = 0; index < inputAsCharArr.Length / 2; index++)
            {
                firstHalf += inputAsCharArr[index];
            }

            var secondHalf = string.Empty;
            for (int index = inputAsCharArr.Length - 1; index >= inputAsCharArr.Length / 2; index--)
            {
                secondHalf += inputAsCharArr[index];
            }

            if (firstHalf == secondHalf)
            {
                return isPalendrome = true;
            }
        }

        return isPalendrome;
    }
}