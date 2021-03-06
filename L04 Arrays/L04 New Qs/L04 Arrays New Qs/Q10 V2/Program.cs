﻿using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You are given a field size and the indexes of ladybugs inside the field.
        //After that on every new line until the "end" command is given, 
        //a ladybug changes its position either to its left or to its right by a given fly length. 
        //A command to a ladybug looks like this: "0 right 1".
        //This means that the little insect placed on index 0 should fly one index to its right.
        //If the ladybug lands on a fellow ladybug, it continues to fly in the same direction by the same fly length.
        //If the ladybug flies out of the field, it is gone.

        //If you are given ladybug index that does not have ladybug there, nothing happens.
        //If you are given ladybug index that is outside the field, nothing happens. 
        //Your job is to create the program, simulating the ladybugs flying around doing nothing. 
        //At the end, print all cells in the field separated by blank spaces.
        //For each cell that has a ladybug on it print '1' and for each empty cells print '0'.
        //For the example above, the output should be '0 1 0'.

        int sizeOfArray = int.Parse(Console.ReadLine());

        var array = new int[sizeOfArray];

        var initialIndexs = Console.ReadLine() // get initial ladybug indexs
        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

        foreach (var index in initialIndexs) // set chosen indexs to 1
        {
            bool insideArray = index < sizeOfArray && index >= 0;
            if (insideArray == true)
            {
                array[index] = 1;
            }
        }

        string command = Console.ReadLine();
        while (command != "end")
        {
            var inputTokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var startIndex = int.Parse(inputTokens[0]);
            string direction = inputTokens[1];
            var moves = int.Parse(inputTokens[2]);

            bool outsideArray = startIndex >= sizeOfArray || array[startIndex] == 0 || startIndex < 0;
            if (outsideArray == true)
            {
                command = Console.ReadLine();
                continue;
            }

            if (moves == 0)
            {
                command = Console.ReadLine();
                continue;
            }

            array[startIndex] = 0;
            if (direction == "right")
            {
                int currentIndex = startIndex + moves;

                bool keepGoing = true;
                while (keepGoing == true)
                {
                    if (currentIndex >= sizeOfArray || currentIndex < 0)
                    {
                        keepGoing = false;
                    }
                    else
                    {
                        bool indexTaken = array[currentIndex] != 0;
                        if (indexTaken == true) //taken
                        {
                            currentIndex += moves;
                        }
                        else
                        {
                            array[currentIndex] = 1;
                            keepGoing = false;
                        }
                    }
                }
            }
            else // left 
            {
                int currentIndex = startIndex - moves;

                bool keepGoing = true;
                while (keepGoing == true)
                {
                    if (currentIndex < 0 || currentIndex >= sizeOfArray)
                    {
                        keepGoing = false;
                    }
                    else
                    {
                        bool indexTaken = array[currentIndex] != 0;
                        if (indexTaken == true)
                        {
                            currentIndex -= moves;
                        }
                        else
                        {
                            array[currentIndex] = 1;
                            keepGoing = false;
                        }
                    }

                }
            }

            command = Console.ReadLine();
        }

        Console.WriteLine(string.Join(" ", array));
    }
}