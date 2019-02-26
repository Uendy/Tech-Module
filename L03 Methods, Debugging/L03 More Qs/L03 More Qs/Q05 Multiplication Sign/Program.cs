using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //You are given a number num1, num2 and num3.
        //Write a program that finds if num1 * num2 * num3 (the product) is negative, positive or zero.
        //Try to do this WITHOUT multiplying the 3 numbers.

        var listOfNumbers = new List<int>();

        ReadNumbers(listOfNumbers);

        CheckIfZero(listOfNumbers);

        CheckIfNegative(listOfNumbers);

         Console.WriteLine("positive"); // if you got to here -> it's positive
    }

    public static List<int> ReadNumbers(List<int> listOfNumbers) ///Input the numbers
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());

        listOfNumbers.Add(num1);
        listOfNumbers.Add(num2);
        listOfNumbers.Add(num3);

        return listOfNumbers;
    }
    public static List<int> CheckIfZero(List<int> listOfNumbers) /// check if any of them is a zero
    {
        foreach (var number in listOfNumbers)
        {
            if (number == 0)
            {
                Console.WriteLine("zero");
                Environment.Exit(0);
            }
        }

        return listOfNumbers;
    }

    public static List<int> CheckIfNegative(List<int> listOfNumbers) /// check if any are negative
    {
        int numberOfNegative = 0;

        foreach (var number in listOfNumbers)
        {
            string numberAsString = number.ToString();
            var numberAsCharArray = numberAsString.ToCharArray();

            if (numberAsCharArray[0] == '-')
            {
                numberOfNegative++;
            }
        }

        if (numberOfNegative == 1 || numberOfNegative == 3) // since -a x -b == +ab
        {
            Console.WriteLine("negative");
            Environment.Exit(0);
        }

        return listOfNumbers;
    }

}