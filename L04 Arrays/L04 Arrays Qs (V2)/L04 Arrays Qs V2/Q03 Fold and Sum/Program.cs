using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read an array of 4*k integers, fold it like shown below, 
        //and print the sum of the upper and lower two rows (each holding 2 * k integers):

        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var length = array.Length / 2;

        var firstHalf = array
            .Take(length)
            .ToArray();
        var secondHalf = array
            .Skip(length)
            .Take(length)
            .ToArray();

        int halfArrayLength = length / 2;

        var firstArrayOutPut = new int[halfArrayLength]; // firstArray
        firstArrayOutPut = FoldAndSum(firstHalf, halfArrayLength);
        firstArrayOutPut = firstArrayOutPut.Reverse().ToArray(); // since it returns it the wrong way around

        var secondArrayOutPut = new int[halfArrayLength]; // secondArray
        secondArrayOutPut = FoldAndSum(secondHalf, halfArrayLength);
        
        var outPutArray = firstArrayOutPut.Concat(secondArrayOutPut);
        string outPut = string.Join(" ", outPutArray);
        Console.WriteLine(outPut);

    }

    public static int[] FoldAndSum(int[] firstHalf, int halfArrayLength) ////Folds and Sums the array
    {
        int[] foldedAndSummedArray = new int[halfArrayLength];

        for (int index = 0; index < halfArrayLength; index++) 
        {
            int rightSideIndex = halfArrayLength * 2 - 1 - index;
            foldedAndSummedArray[index] = firstHalf[index] + firstHalf[rightSideIndex];
        }

        return foldedAndSummedArray;
    }
}