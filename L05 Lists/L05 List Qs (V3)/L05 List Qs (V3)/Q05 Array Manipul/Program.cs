using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a program that reads an array of integers from the console and set of commands and executes them over the array. The commands are as follows:
        //  •	add<index> < element > – adds element at the specified index(elements right from this position inclusively are shifted to the right).
        //  •	addMany<index> < element 1 > < element 2 > … < element n > – adds a set of elements at the specified index.
        //  •	contains < element > – prints the index of the first occurrence of the specified element(if exists) in the array or - 1 if the element is not found.
        //  •	remove < index > – removes the element at the specified index.
        //  •	shift < positions > – shifts every element of the array the number of positions to the left(with rotation).
        //  o For example, [1, 2, 3, 4, 5] -> shift 2 -> [3, 4, 5, 1, 2]
        //  •	sumPairs – sums the elements in the array by pairs(first + second, third + fourth, …).
        //  o For example, [1, 2, 4, 5, 6, 7, 8] -> [3, 9, 13, 8].
        //  •	print – stop receiving more commands and print the last state of the array.


        // Example:
        //  Input                      Output
        //1 2 4 5 6 7                     0
        //  add 1 8                       1
        // contains 1           [1, 8, 2, 4, 5, 6, 7]
        // contains - 3
        // print   0
        #endregion

        // Reading input:
        var list = new List<int>();

        // Getting commandline and command
        var commands = Console.ReadLine().Split(' ').ToList();

        // Read commands and execute
        while (commands[0] != "print")
        {
            switch (commands[0])
            {
                case "add":
                    //
                    break;

                case "addmany":
                    //
                    break;

                case "contains":
                    //
                    break;

                case "remove":
                    //
                    break;

                case "shift":
                    //
                    break;

                case "sumPairs":
                    //
                    break;


                default:
                    break;
            }
            // Read next command
            commands = Console.ReadLine().Split(' ').ToList();
        }

        // Printing output
        Console.WriteLine(string.Join(" ", list));
    }
}