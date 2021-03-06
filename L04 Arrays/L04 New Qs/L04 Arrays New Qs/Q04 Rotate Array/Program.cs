﻿using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that receives an array and number of rotations you have to perform 
        //(first element goes at the end) Print the resulting array.

        var inputAsString = Console.ReadLine();
        var array = inputAsString.Split(' ').Select(int.Parse).ToArray();

        int numberOfRotations = int.Parse(Console.ReadLine());

        while (numberOfRotations >= array.Count())
        {
            numberOfRotations -= array.Count();
        }

        var temporaryArray = new int[array.Count()];

        int index = 0;
        foreach (var num in array)
        {
            if (index - numberOfRotations < 0)
            {
                temporaryArray[array.Count() - numberOfRotations + index] = array[index];
            }
            else
            {
                temporaryArray[index - numberOfRotations] = array[index];
            }

            index++;
        }

        Console.WriteLine(string.Join(" ", temporaryArray));
    }
}
