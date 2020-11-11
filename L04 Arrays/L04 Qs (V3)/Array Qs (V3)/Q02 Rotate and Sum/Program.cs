using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: To “rotate an arrTo “rotate an array on the right” means to move its last element first: {1, 2, 3}  {3, 1, 2}.
        // Write a program to read an array of n integers(space separated on a single line) and an integer k, rotate the array right k times and sum the obtained arrays after each rotation as shown below. ay on the right” means to move its last element first: {1, 2, 3}  {3, 1, 2}.
        // Write a program to read an array of n integers(space separated on a single line) and an integer k, rotate the array right k times and sum the obtained arrays after each rotation as shown below.

        // Example:
        //    Input:             Output:            Comment:
        //  3 2 4 - 1            3 2 5 6            rotated1[] = -1  3  2  4
        //     2                                    rotated2[] =  4 -1  3  2
        //                                               sum[] =  3  2  5  6
        #endregion

        // Reading input:
        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); // also parsing to int
        int rotations = int.Parse(Console.ReadLine());

        int arrLength = array.Length;

        // Cycling and rotating in one go:
        var sum = new int[arrLength];
        for (int index = 0; index < arrLength; index++)
        {
            int currentNum = array[index]; // get the num we will rotate (drop into next indexs)

            for (int roatation = 1; roatation <= rotations; roatation++) // rotate the index right 
            {
                int rotationIndex = OutOfBoundsCheck(index + roatation, arrLength); // see if the index + rotation needs reducing
                sum[rotationIndex] += currentNum; 
            }
        }
        Console.WriteLine(string.Join(" ", sum));
    }

    /// Check for the current index to see if it excedes arrLength and if so to reduce it by the arrLength
    public static int OutOfBoundsCheck(int index, int arrLength)
    {
        bool checkIfOutOfBounds = index > arrLength - 1;
        if (checkIfOutOfBounds == true)
        {
            index -= arrLength;
        }

        return index;
    }
}