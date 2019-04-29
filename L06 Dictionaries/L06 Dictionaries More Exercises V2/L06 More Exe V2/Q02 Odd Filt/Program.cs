using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program, which receives an array of integers(space-separated), removes all the odd numbers,
        //then converts the remaining numbers to odd numbers, based on these conditions:
        //•	If the number is larger than the average of the collection of remaining numbers, add 1 to it.
        //•	If the number is smaller than the average of the collection of remaining numbers, subtract 1 from it.
        //After you convert all of the elements to odd numbers, print them on the console(space - separated).

        var listOfInts = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        listOfInts.RemoveAll(x => x % 2 != 0);

        double average = listOfInts.Average();
        for (int index = 0; index < listOfInts.Count(); index++)
        {
            int currentNum = listOfInts[index];
            if (currentNum <= average)
            {
                listOfInts[index]--;
            }
            else
            {
                listOfInts[index]++;
            }
        }

        string outPut = string.Join(" ", listOfInts);
        Console.WriteLine(outPut);

    }
}