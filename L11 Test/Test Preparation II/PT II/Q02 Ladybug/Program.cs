﻿using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region;
        //You are given a field size and the indexes of ladybugs inside the field.
        //After that on every new line until the "end" command is given, a ladybug changes its position either to its left or to its right by a given fly length. 

        //A command to a ladybug looks like this: "0 right 1".
        //This means that the little insect placed on index 0 should fly one index to its right.
        //If the ladybug lands on a fellow ladybug, it continues to fly in the same direction by the same fly length. 
        //If the ladybug flies out of the field, it is gone.

        //For example, imagine you are given a field with size 3 and ladybugs on indexes 0 and 1.
        //If the ladybug on index 0 needs to fly to its right by the length of 1(0 right 1) it will attempt to land on index 1,
        //but as there is another ladybug there it will continue further to the right by additional length of 1, landing on index 2.
        //After that, if the same ladybug needs to fly to its right by the length of 1(2 right 1), it will land somewhere outside of the field, its gone.

        //If you are given ladybug index that does not have ladybug there, nothing happens.
        //If you are given ladybug index that is outside the field, nothing happens. 

        //Your job is to create the program, simulating the ladybugs flying around doing nothing. 
        //At the end, print all cells in the field separated by blank spaces. 
        //For each cell that has a ladybug on it print '1' and for each empty cells print '0'.For the example above, 
        //the output should be '0 1 0'.

        //sort out array size and initialize the starting positions of the ladybugs
        #endregion //the question

        var size = int.Parse(Console.ReadLine());

        var array = new int[size];

        var indexsOfLadyBugs = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();

        for (int index = 0; index < size; index++)
        {
            bool noLadyBug = !indexsOfLadyBugs.Contains(index);
            if (noLadyBug)
            {
                array[index] = 0;
            }
            else
            {
                array[index] = 1;
            }
        }

        string input = Console.ReadLine();
        while (input != "end")
        {
            var inputTokens = input.Split(' ').ToArray();

            int initialIndex = int.Parse(inputTokens[0]);

            bool isOutsideBounds = initialIndex < 0 || initialIndex >= array.Length; // check if index and ladybug are acceptable
            if (isOutsideBounds)
            {
                input = Console.ReadLine();
                continue;
            }

            bool noLadyBug = array[initialIndex] == 0;
            if (noLadyBug)
            {
                input = Console.ReadLine();
                continue;
            }

            array[initialIndex] = 0;

            string direction = inputTokens[1].ToLower();
            int spaces = int.Parse(inputTokens[2]);

            MoveLadybug(array, initialIndex, spaces, direction);

            input = Console.ReadLine();
        }
        string outPut = string.Join(" ", array);
        Console.WriteLine(outPut);
    }

    //moves ladybug until it either lands or leaves array
    private static void MoveLadybug(int[] array, int initialIndex, int spaces, string direction)
    {
        bool leftArrayOrLanded = false;
        while (!leftArrayOrLanded)
        {

            switch (direction)
            {
                case "left":
                    initialIndex -= spaces;
                    break;

                case "right":
                    initialIndex += spaces;
                    break;
            }

            bool outSideBounds = initialIndex < 0 || initialIndex >= array.Length;
            if (outSideBounds)
            {
                leftArrayOrLanded = true; // it left
                continue;
            }

            bool steppedOn = array[initialIndex] == 1;
            if (steppedOn)
            {
                continue;
            }

            array[initialIndex] = 1;
            leftArrayOrLanded = true;
        }
    }
}
