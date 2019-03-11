using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that determines if there exists an element in the array,
        //such that the sum of the elements on its left is equal to the sum of the elements on its right.
        //If there are no elements to the left / right, their sum is considered to be 0.
        //Print the index that satisfies the required condition or “no” if there is no such index.

        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        bool EqualSums = false;

        for (int index = 0; index < array.Length; index++)
        {
            var currentNum = array[index];

            int leftNum = 0;
            int rightNum = 0;
            if (index != 0)
            {
                for (int indexOfLeft = 0; indexOfLeft < index; indexOfLeft++) // left of num
                {
                    leftNum += array[indexOfLeft];

                    if (index == array.Length - 1)
                    {
                        if (leftNum == rightNum)
                        {
                            EqualSums = true;
                            Console.WriteLine(index);
                            Environment.Exit(0);
                        }
                    }
                }

                for (int indexOfRight = index + 1; indexOfRight < array.Length; indexOfRight++) // right of index
                {
                    rightNum += array[indexOfRight];
                }
                if (leftNum == rightNum)
                {
                    EqualSums = true;
                    Console.WriteLine(index);
                    Environment.Exit(0);
                }

            }
            else // index == 0 => leftOfNum = 0;
            {
                leftNum = 0;
                for (int indexOfRight = index + 1; indexOfRight < array.Length; indexOfRight++) // right of index
                {
                    rightNum += array[indexOfRight];
                    if (leftNum == rightNum)
                    {
                        EqualSums = true;
                        Console.WriteLine(index);
                        Environment.Exit(0);
                    }
                }
            }

            if (leftNum != rightNum) // check to see if you return both to zero
            {
                leftNum = 0;
                rightNum = 0;
            }
            else
            {
                Console.WriteLine(index);
                Environment.Exit(0);
            }
        }

        if (EqualSums == false)
        {
            Console.WriteLine("no");
        }
    }
}