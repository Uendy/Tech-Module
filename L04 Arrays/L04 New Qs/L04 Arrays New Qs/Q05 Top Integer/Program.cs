using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //Write a program to find all the top integers in an array.
        //A top integer is an integer which is bigger than all the elements to its right. 

        var array = Console.ReadLine()
            .Split(' ').
            Select(int.Parse)
            .ToArray();

        var listOfTopNumbers = new List<int>();

        for (int index = 0; index < array.Length; index++)
        {
            var currentNumber = array[index];
            bool isTopNumber = true;

            if (index == array.Length - 1) // since the last number will always be added
            {
                listOfTopNumbers.Add(currentNumber);
            }
            else
            {
                for (int i = index + 1; i < array.Length; i++)
                {
                    var checkedNumber = array[i];

                    bool theCheck = currentNumber > checkedNumber;
                    if (theCheck == false)
                    {
                        isTopNumber = false;
                    }
                }

                if (isTopNumber == true)
                {
                    listOfTopNumbers.Add(currentNumber);
                }
            }
        }

        string output = string.Join(" ", listOfTopNumbers);
        Console.WriteLine(output);
    }
}