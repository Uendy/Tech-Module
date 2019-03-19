using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //To “rotate an array on the right” means to move its last element first: {1, 2, 3}  {3, 1, 2}.
        //Write a program to read an array of n integers(space separated on a single line) and an integer k, 
        //rotate the array right k times and sum the obtained arrays after each rotation as shown below.
        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var sum = new int[array.Length];

        int rotateBy = int.Parse(Console.ReadLine());

        for (int rotate = 0; rotate < rotateBy; rotate++)
        {
            int lastElement = array[array.Length - 1];
            for (int index = array.Length - 1; index > 0; index--)
            {
                array[index] = array[index - 1];
            }
            array[0] = lastElement;

            for (int sumIndex = 0; sumIndex < array.Length; sumIndex++)
            {
                sum[sumIndex] += array[sumIndex];
            }
        }

        Console.WriteLine(string.Join(" ", sum));
    }
}