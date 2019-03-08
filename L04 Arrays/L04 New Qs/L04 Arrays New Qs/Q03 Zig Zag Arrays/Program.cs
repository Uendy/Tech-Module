using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //Write a program which creates 2 arrays.
        //You will be given an integer n.
        //On the next n lines you get 2 integers.
        //Form 2 arrays as shown below.

        int numberOfArrays = int.Parse(Console.ReadLine());

        var firstArr = new int[numberOfArrays];
        var secondArr = new int[numberOfArrays];

        for (int index = 0; index < numberOfArrays; index++) //index % 2 == 0 -> firstArr else: -> secondArr
        {
            var currentArrayString = Console.ReadLine();
            var currentArray = currentArrayString.Split(' ');

            bool evenIndex = index % 2 == 0;
            if (evenIndex == true)
            {
                firstArr[index] = int.Parse(currentArray[0]);
                secondArr[index] = int.Parse(currentArray[1]);
            }
            else
            {
                firstArr[index] = int.Parse(currentArray[1]);
                secondArr[index] = int.Parse(currentArray[0]);
            }
        }

        var firstArrOutput = string.Join(" ", firstArr);
        var secondArrOutput = string.Join(" ", secondArr);

        Console.WriteLine(firstArrOutput);
        Console.WriteLine(secondArrOutput);
    }
}