using System;
using System.Collections.Generic;
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
            var arrOfInput = input.Split(' ');

            switch (arrOfInput[0])
            {
                case "exchange":
                    int indexOfPivot = int.Parse(arrOfInput[1]);
                    bool aboveIndex = indexOfPivot <= array.Count() - 1;
                    //
                    if (aboveIndex == true)
                    {
                        var tempArray = new int[array.Count()];
                        int overDraftIndex = 0; // when the index overflows this is a counter for which index of original array to use
                        for (int index = indexOfPivot; index < indexOfPivot + array.Count(); index++)
                        {
                            if (index < array.Count())
                            {
                                tempArray[index - indexOfPivot] = array[index];
                            }
                            else
                            {
                                tempArray[index - indexOfPivot] = array[overDraftIndex];
                                overDraftIndex++;
                            }
                        }
                        array = tempArray;
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                    break;

                case "min":
                    switch (arrOfInput[1])
                    {
                        case "even":
                            var evenIndexs = new Dictionary<int, int>(); // key = value, value = index
                            for (int index = 0; index <= array.Count(); index += 2)
                            {
                                evenIndexs[array[index]] = index;
                            }
                            var lowestEvenKey = evenIndexs.Keys.Min();
                            if (evenIndexs.ContainsKey(lowestEvenKey))
                            {
                                Console.WriteLine(evenIndexs[lowestEvenKey]);
                            }
                            else
                            {
                                Console.WriteLine("No matches");
                            }
                            break;

                        case "odd":
                            var oddIndexs = new Dictionary<int, int>();
                            for (int index = 1; index < array.Count(); index += 2)
                            {
                                oddIndexs[array[index]] = index;
                            }
                            var lowestOddKey = oddIndexs.Keys.Min();
                            if (oddIndexs.ContainsKey(lowestOddKey))
                            {
                                Console.WriteLine(oddIndexs[lowestOddKey]);
                            }
                            else
                            {
                                Console.WriteLine("No matches");
                            }
                            break;
                    }
                    break;

                case "max":
                    switch (arrOfInput[1])
                    {
                        case "even":
                            var evenIndexs = new Dictionary<int, int>();
                            for (int index = 0; index <= array.Count(); index += 2)
                            {
                                evenIndexs.Add(array[index]);
                            }
                            Console.WriteLine(evenIndexs.Max());
                            break;

                        case "odd":
                            var oddIndexs = new List<int>();
                            for (int index = 1; index < array.Count(); index += 2)
                            {
                                oddIndexs.Add(array[index]);
                            }
                            Console.WriteLine(oddIndexs.Max());
                            break;
                    }
                    break;

                case "first":
                    int firstCount = int.Parse(arrOfInput[1]);

                    break;

                case "last":
                    int lastCount = int.Parse(arrOfInput[1]);
                    break;

                default:
                    break;
            }


            input = Console.ReadLine();
        }
    }

}