using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //Write a program that reads a list of integers.Then until you receive "end", you will receive different commands:
        //Add { number}: add a number to the end of the list.
        //Remove { number}: remove a number from the list.
        //RemoveAt { index}: remove a number at a given index.
        //Insert { number}
        //            { index}: insert a number at a given index.
        //Note: All the indices will be valid!
        //When you receive the "end" command, print the final state of the list(separated by spaces).

        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        var input = Console.ReadLine();
        while (input != "end")
        {
            var inputTokens = input.Split(' ');
            switch (inputTokens[0])
            {
                case "Add":
                    int addedNumer = int.Parse(inputTokens[1]);
                    list.Add(addedNumer);
                    break;

                case "Remove":
                    int removedNumber = int.Parse(inputTokens[1]);
                    list.Remove(removedNumber);
                    break;

                case "RemoveAt":
                    int removeIndex = int.Parse(inputTokens[1]);
                    list.RemoveAt(removeIndex);
                    break;

                case "Insert":
                    int insertedNumber = int.Parse(inputTokens[1]);
                    int insertAtIndex = int.Parse(inputTokens[2]);
                    list.Insert(insertAtIndex, insertedNumber);
                    break;
            }

            input = Console.ReadLine();
        }

        string outPut = string.Join(" ", list);
        Console.WriteLine(outPut);
    }
}