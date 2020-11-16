using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a program that finds the longest sequence of equal elements in an array of integers. If several longest sequences exist, print the leftmost one.
        //       Input	                     Output
        // 2 1 1 2 3 3 2 2 2 1               2 2 2
        //   1 1 1 2 3 1 3 3                 1 1 1
        //      4 4 4 4                     4 4 4 4
        // 0 1 1 5 2 2 6 3 3                  1 1
        #endregion

        // Reading input:
        var array = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

        // basically go from righ to left, and stop when i != i + 1 || i < array.Length - 2(as it goes to +1)
        // if the num is strictly bigger than currentMax then change them and have a var for which num it is, then print it * max

        // Set up variables
        var maxSequence = 0;
        var element = ' ';
        var currentSequence = 0;

        // cycle right:
        for (int index = 0; index < array.Count() - 1; index++)
        {
            char current = array[index];
            char next = array[index + 1];

            if (current == next)
            {
                currentSequence++; 
            }
            else // not sequence
            {
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence; // updating high score
                    element = current;
                }
                currentSequence = 0; // annuling highscore
            }
        }

        // last check to see if with the last cycle we hit a new record:
        if (currentSequence > maxSequence)
        {
            maxSequence = currentSequence; // updating high score
            element = array[array.Length - 1];
        }

        // Printing output
        Console.WriteLine(new string(element, maxSequence));
    }
}