using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //Write a method to print the smallest of three integer numbers. Use appropriate name for the method.
        var listOfNumbers = new List<int>();

        ReadNumbers(listOfNumbers);

        Console.WriteLine(ReturnSmallest(listOfNumbers));

    }

    public static List<int> ReadNumbers(List<int> listOfNumbers)
    {
        //static var listOfNumbers = new List<int>();

        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());

        listOfNumbers.Add(firstNum);
        listOfNumbers.Add(secondNum);
        listOfNumbers.Add(thirdNum);

        return listOfNumbers;
    }

    public static int ReturnSmallest(List<int> listOfNumbers)
    {
        int smallest = int.MaxValue;

        foreach (var currentNum in listOfNumbers)
        {
            bool isSmaller = currentNum < smallest;
            if (isSmaller == true)
            {
                smallest = currentNum;
            }
        }

        return smallest;
    }
}
