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

        var outPutArray = new int[array.Length];

        int rotateBy = int.Parse(Console.ReadLine());

        //for (int index = 0; index < array.Length; index++)
        //{
        //    for (int rotation = 1; rotation <= rotateBy; rotation++)
        //    {
        //        int rotatedIndex = index + rotation;
        //        rotatedIndex %= array.Length;
        //        outPutArray[index] += array[rotatedIndex];
        //    }
        //}
        for (int rotation = 2; rotation <= rotateBy + 1; rotation++)
        {
            for (int index = 0; index < array.Length; index++)
            {
                int rotatedIndex = index + rotation;
                rotatedIndex %= array.Length;
                outPutArray[index] += array[rotatedIndex];
            }
        }

        string outPut = string.Join(" ", outPutArray);
        Console.WriteLine(outPut);
    }
}