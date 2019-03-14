using System;
using System.Collections.Generic;
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

        var array = new bool[sizeOfArray];

        var initialBeeIndexs = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        for (int index = 0; index < initialBeeIndexs.Length; index++)
        {
            var currentBeeIndex = initialBeeIndexs[index];

            if (array.Length > currentBeeIndex)
            {
                array[currentBeeIndex] = true;
            }
        }

        string input = Console.ReadLine();

        while (input != "end")
        {
            var inputTokens = input.Split(' ').ToArray();

            int initialIndex = int.Parse(inputTokens[0]);
            if (array[initialIndex] == false)
            {
                continue;
            }

            int moves = int.Parse(inputTokens[2]);

            if (inputTokens[1] == "right")
            {
                int currentIndex = initialIndex + moves;
                bool outsideArray = array.Length - 1  < currentIndex;
                if (outsideArray == true)
                {
                    array[initialIndex] = false;
                    break;
                }
                bool isTaken = array[currentIndex] == true;

                while (isTaken == true)
                {
                    currentIndex++;
                    if (outsideArray == true)
                    {
                        //array[initialIndex] = false;
                        break;
                    }
                    isTaken = array[currentIndex] == true;
                }

                if (outsideArray == false)
                {
                    array[initialIndex] = false;
                    array[currentIndex] = true;
                }
            }
            else // left
            {
                int currentIndex = initialIndex + moves;

                bool isTaken = array[currentIndex] == true;
                while (isTaken == true)
                {
                    currentIndex--;
                }

                bool outSideArray = 0 > currentIndex;
                if (outSideArray == false)
                {
                    array[initialIndex] = false;
                    array[currentIndex] = true;
                }
            }

            input = Console.ReadLine();
        }

        var arrayOfBits = new int[array.Length];
        for (int index = 0; index < array.Length; index++)
        {
            if (array[index] == true)
            {
                arrayOfBits[index] = 1;
            }
        }

        string outPut = string.Join(" ", arrayOfBits);
        Console.WriteLine(outPut);
    }
}