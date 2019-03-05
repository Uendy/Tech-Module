using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        //Trifon has finally become a junior developer and has received his first task. 
        //It’s about manipulating an array of integers.
        //He is not quite happy about it, since he hates manipulating arrays. 
        //They are going to pay him a lot of money, though, and he is willing to give somebody half of it if to help him do his job. 
        //You, on the other hand, love arrays (and money) so you decide to try your luck.
        //The array may be manipulated by one of the following commands
        //•	exchange { index} – splits the array after the given index, and exchanges the places of the two resulting sub - arrays.E.g. [1, 2, 3, 4, 5]->exchange 2->result: [4, 5, 1, 2, 3]
        //    o If the index is outside the boundaries of the array, print “Invalid index”
        //•	max even/odd– returns the INDEX of the max even/odd element -> [1, 4, 8, 2, 3] -> max odd -> print 4
        //•	min even/odd – returns the INDEX of the min even/odd element -> [1, 4, 8, 2, 3] -> min even > print 3
        //o If there are two or more equal min/max elements, return the index of the rightmost one
        //o If a min/max even/odd element cannot be found, print “No matches”
        //•	first {count
        //}
        //even/odd– returns the first {count} elements -> [1, 8, 2, 3] -> first 2 even -> print[8, 2]
        //•	last {count} even/odd – returns the last {count} elements -> [1, 8, 2, 3] -> last 2 odd -> print[1, 3]
        //o   If the count is greater than the array length, print “Invalid count”
        //o If there are not enough elements to satisfy the count, print as many as you can.If there are zero even/odd elements, print an empty array “[]”
        //•	end – stop taking input and print the final state of the array

        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        string input = Console.ReadLine();
        while (input != "end")
        {
            var inputArr = input.Split(' ').ToArray();

            switch (inputArr[0])
            {
                case "exchange":
                    int shiftBy = int.Parse(inputArr[1]);

                    if (shiftBy > array.Length)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        array = ExchangeMethod(array, shiftBy);
                    }
                    break;

                case "min":

                    switch (inputArr[1])
                    {
                        case "odd":
                            MinOdd(array);
                            break;

                        case "even":
                            MinEven(array);
                            break;
                    }
                    break;

                case "max":
                    //
                    break;

                case "first":
                    int firstCount = int.Parse(inputArr[1]);

                    break;

                case "last":
                    int lastCount = int.Parse(inputArr[1]);
                    break;
            }

            input = Console.ReadLine();
        }

        var sb = new StringBuilder();
        foreach (var num in array)
        {
            sb.Append(num + " ");
        }
        var output = sb.ToString();
        Console.WriteLine(output);
    }
    public static int[] ExchangeMethod(int[] array, int shiftBy)
    {
        int[] temporaryArr = new int[array.Length];

        for (int index = 0; index < array.Length; index++)
        {
            int actualIndex = index + shiftBy;
            if (actualIndex >= array.Length)
            {
                actualIndex -= array.Length;
                temporaryArr[actualIndex] = array[index];
            }
            else
            {
                temporaryArr[actualIndex] = array[index];
            }
        }

        return temporaryArr;
    }

    public static void MinOdd(int[] array)
    {
        int lowestOdd = int.MaxValue;
        int lowestOddIndex = int.MaxValue;

        foreach (var num in array)
        {
            bool isOdd = num % 2 != 0;
            if (isOdd == true)
            {
                if (num <= lowestOdd)
                {
                    lowestOdd = num;
                    lowestOddIndex = array.ToList().IndexOf(num);
                }
            }
        }

        if (lowestOddIndex != int.MaxValue)
        {
            Console.WriteLine(lowestOddIndex);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }

    public static void MinEven(int[] array)
    {
        int lowestEven = int.MaxValue;
        int lowestEvenIndex = int.MaxValue;

        foreach (var num in array)
        {
            bool isEven = num % 2 == 0;
            if (isEven == true)
            {
                if (num <= lowestEven)
                {
                    lowestEven = num;
                    lowestEvenIndex = array.ToList().IndexOf(num);
                }
            }
        }

        if (lowestEvenIndex != int.MaxValue)
        {
            Console.WriteLine(lowestEvenIndex);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
}
