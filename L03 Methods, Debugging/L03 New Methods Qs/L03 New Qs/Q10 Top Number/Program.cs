using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //A top number is an integer that holds the following properties:
        //•	Its sum of digits is divisible by 8, e.g. 8, 16, 88.
        //•	Holds at least one odd digit, e.g. 232, 707, 87578.
        //Write a program to print all master numbers in the range[1…n].

        int input = int.Parse(Console.ReadLine());

        IsTopNumber(input);
    }

    public static void IsTopNumber(int input)
    {
        //var listOfTopNumbers = new List<int>();

        for (int num = 0; num <= input; num++)
        {
            var inputAsCharArr = num.ToString().ToCharArray();
            bool atleastOneOdd = false;
            int sum = 0;
            foreach (var digit in inputAsCharArr)
            {
                int currentNum = digit - '0';
                sum += currentNum;

                if (currentNum % 2 != 0) // odd
                {
                    atleastOneOdd = true;
                }
            }
            bool isDivisableByEight = sum % 8 == 0;


            if (isDivisableByEight == true && atleastOneOdd == true)
            {
                Console.WriteLine(num);
            }
        }

    }
}