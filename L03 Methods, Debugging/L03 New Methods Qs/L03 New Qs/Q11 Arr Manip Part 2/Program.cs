using System;
using System.Linq;
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
                    int splitPoint = int.Parse(inputArr[1]);

                    if (splitPoint > array.Length)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        array = ExchangeMethod(array, splitPoint);
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

                    switch (inputArr[1])
                    {
                        case "odd":
                            MaxOdd(array);
                            break;

                        case "even":
                            MaxEven(array);
                            break;
                    }
                    break;

                case "first":
                    int firstCount = int.Parse(inputArr[1]);
                    if (firstCount > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        break;
                    }

                    string sequence = inputArr[2]; // even or odd
                    switch (sequence)
                    {
                        case "odd":
                            FirstOddFinder(array, firstCount);
                            break;

                        case "even":
                            FirstEvenFinder(array, firstCount);
                                break;
                    }

                    break;

                case "last":
                    int lastCount = int.Parse(inputArr[1]);
                    if (lastCount > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        break;
                    }

                    string evenOrOdd = inputArr[2];
                    switch (evenOrOdd)
                    {
                        case "even":
                            LastEvenFinder(array, lastCount);
                            break;

                        case "odd":
                            LastOddFinder(array, lastCount);
                            break;
                        default:
                            break;
                    }
                    break;
            }

            input = Console.ReadLine();
        }

        // "end"
        var output = string.Join(", ", array);
        Console.WriteLine($"[{output}]");
    }
    public static int[] ExchangeMethod(int[] array, int splitPoint)
    {
        splitPoint += 1; // since it is the index number

        var first = array.Take(splitPoint);
        var second = array.Skip(splitPoint);

        var temptArr = second.Concat(first).ToArray();

        return temptArr;
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

    public static void MaxOdd(int[] array)
    {
        int highestOdd = int.MinValue;
        int highestOddIndex = int.MinValue;

        foreach (var num in array)
        {
            bool isOdd = num % 2 != 0;
            if (isOdd == true)
            {
                if (num >= highestOdd)
                {
                    highestOdd = num;
                    highestOddIndex = array.ToList().IndexOf(num);
                }
            }
        }

        if (highestOddIndex != int.MinValue)
        {
            Console.WriteLine(highestOddIndex);
        }
        else
        { 
            Console.WriteLine("No matches");
        }
    }

    public static void MaxEven(int[] array)
    {
        int highestEven = int.MinValue;
        int highestEvenIndex = int.MinValue;

        foreach (var num in array)
        {
            bool isEven = num % 2 == 0;
            if (isEven == true)
            {
                if (num >= highestEven)
                {
                    highestEven = num;
                    highestEvenIndex = array.ToList().IndexOf(num);
                }
            }
        }

        if (highestEvenIndex != int.MinValue)
        {
            Console.WriteLine(highestEvenIndex);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }

    public static void FirstEvenFinder(int[] array, int firstCount)
    {
        var listOfFirstEven = array.ToList()
            .Where(x => x % 2 == 0).Take(firstCount);

        if (listOfFirstEven.Count() != 0)
        {
            string output = string.Join(", ", listOfFirstEven);
            Console.WriteLine($"[{output}]");
        }
        else
        {
            Console.WriteLine("[]"); // not sure if what they want, line 27://// If there are zero even/odd elements, print an empty array “[]”
        }
    }

    public static void FirstOddFinder(int[] array, int firstCount)
    {
        var listOfFirstOdd = array.ToList()
           .Where(x => x % 2 != 0).Take(firstCount);

        if (listOfFirstOdd.Count() != 0)
        {
            string output = string.Join(", ", listOfFirstOdd);
            Console.WriteLine($"[{output}]");
        }
        else
        {
            Console.WriteLine("[]"); // not sure if what they want, line 27://// If there are zero even/odd elements, print an empty array “[]”
        }

    }

    public static void LastEvenFinder(int[] array, int lastCount)
    {
        var listOfLastEven = array.ToList()
           .Where(x => x % 2 == 0)
           .Reverse() // using .Reverse() x2, since .TakeLast() was removed
           .Take(lastCount)
           .Reverse();

        if (listOfLastEven.Count() != 0)
        {
            string output = string.Join(", ", listOfLastEven);
            Console.WriteLine($"[{output}]");
        }
        else
        {
            Console.WriteLine("[]"); 
        }
    }

    public static void LastOddFinder(int[] array, int lastCount)
    {
        var listOfLastOdd = array.ToList()
           .Where(x => x % 2 != 0)
           .Reverse() // using .Reverse() x2, since .TakeLast() was removed
           .Take(lastCount)
           .Reverse();

        if (listOfLastOdd.Count() != 0)
        {
            string output = string.Join(", ", listOfLastOdd);
            Console.WriteLine($"[{output}]");
        }
        else
        {
            Console.WriteLine("[]");
        }
    }
}
