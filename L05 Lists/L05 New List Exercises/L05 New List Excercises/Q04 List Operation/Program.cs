using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You will be given a list of integer numbers on the first line of input. 
        //You will be receiving operations you have to apply on the list until you receive the "End" command. The possible commands are:
        //•	Add { number} – add number at the end.
        //•	Insert { number} { index} – insert number at given index.
        //•	Remove { index} – remove at index.
        //•	Shift left { count} – first number becomes last ‘count’ times.
        //•	Shift right { count} – last number becomes first ‘count’ times.
        //Note: there is a possibility that the given index is outside of the bounds of the array.
        //In that case print "Invalid index"

        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();


        string command = Console.ReadLine();
        while (command != "End")
        {
            var commandTokens = command.Split(' ').ToList();
            switch (commandTokens[0])
            {
                case "Add":
                    int addedNum = int.Parse(commandTokens[1]);
                    list.Add(addedNum);
                    break;

                case "Insert":
                    int insertedNum = int.Parse(commandTokens[1]);
                    int indexOfNum = int.Parse(commandTokens[2]);
                    if (indexOfNum > list.Count() || indexOfNum < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        list.Insert(indexOfNum, insertedNum);
                    }
                    break;

                case "Remove":
                    int removedIndex = int.Parse(commandTokens[1]);
                    if (removedIndex > list.Count() || removedIndex < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        list.RemoveAt(removedIndex);
                    }
                    break;

                case "Shift":
                    int shiftBy = int.Parse(commandTokens[2]);
                    if (shiftBy < 0)
                    {
                        Console.WriteLine("Invalid index");
                        break;
                    }
                    while (shiftBy > list.Count())
                    {
                        shiftBy -= list.Count();
                    }

                    var temporaryList = new List<int>(list);
                    if (commandTokens[1] == "left")
                    {
                        for (int index = list.Count() - 1; index >= 0; index--)
                        {
                            int oldInddex = index;
                            int newIndex = index - shiftBy;
                            if (newIndex < 0)
                            {
                                newIndex += list.Count();
                            }

                            temporaryList[newIndex] = list[index];
                        }
                    }
                    else if (commandTokens[1] == "right")
                    {
                        for (int index = 0; index < list.Count(); index++)
                        {
                            int newIndex = index + shiftBy;
                            if (newIndex > list.Count() - 1)
                            {
                                newIndex -= list.Count();
                            }
                            temporaryList[newIndex] = list[index];
                        }
                    }

                    list = temporaryList.ToList();
                    break;
            }

            command = Console.ReadLine();
        }

        string outPut = string.Join(" ", list);
        Console.WriteLine(outPut);
        Environment.Exit(0);
    }
}