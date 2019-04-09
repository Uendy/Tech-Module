using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Next, we are going to implement more complicated list commands, extending the previous task.
        //Again, read a list and keep reading commands until you receive "end":

        //Contains { number} – check if the list contains the number and if so - print "Yes", otherwise print "No such number".
        //PrintEven – print all the even numbers, separated by a space.
        //PrintOdd – print all the odd numbers, separated by a space.
        //GetSum – print the sum of all the numbers.
        //Filter { condition}{ number} – print all the numbers that fulfill the given condition.The condition will be either '<', '>', ">=", "<=".
        //After the end command, print the list only if you have made some changes to the original list. Changes are made only from the commands from the previous task.

        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        bool changesMade = false;

        var input = Console.ReadLine();
        while (input != "end")
        {
            var inputTokens = input.Split(' ');
            switch (inputTokens[0])
            {
                case "Add":
                    changesMade = true;
                    int addedNumer = int.Parse(inputTokens[1]);
                    list.Add(addedNumer);
                    break;

                case "Remove":
                    changesMade = true;
                    int removedNumber = int.Parse(inputTokens[1]);
                    list.Remove(removedNumber);
                    break;

                case "RemoveAt":
                    changesMade = true;
                    int removeIndex = int.Parse(inputTokens[1]);
                    list.RemoveAt(removeIndex);
                    break;

                case "Insert":
                    changesMade = true;
                    int insertedNumber = int.Parse(inputTokens[1]);
                    int insertAtIndex = int.Parse(inputTokens[2]);
                    list.Insert(insertAtIndex, insertedNumber);
                    break;

                case "Contains":
                    int checkedNumer = int.Parse(inputTokens[1]);
                    bool isContained = list.Contains(checkedNumer);
                    if (isContained == true)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                    break;

                case "PrintEven":
                    var listOfEven = list.Where(x => x % 2 == 0).ToList();
                    var evenOutPut = string.Join(" ",listOfEven);
                    Console.WriteLine(evenOutPut);
                    break;

                case "PrintOdd":
                    var listOfOdd = list.Where(x => x % 2 != 0).ToList();
                    var oddOutPut = string.Join(" ", listOfOdd);
                    Console.WriteLine(oddOutPut);
                    break;

                case "GetSum":
                    int sum = list.Sum();
                    Console.WriteLine(sum);
                    break;

                case "Filter":
                    var filteredList = new List<int>();
                    int filter = int.Parse(inputTokens[2]);
                    string condition = inputTokens[1];
                    if (condition == ">")
                    {
                        foreach (var num in list)
                        {
                            if (num > filter)
                            {
                                filteredList.Add(num);
                            }
                        }
                    }
                    else if (condition == "<")
                    {
                        foreach (var num in list)
                        {
                            if (num < filter)
                            {
                                filteredList.Add(num);
                            }
                        }
                    }
                    else if (condition == ">=")
                    {
                        foreach (var num in list)
                        {
                            if (num >= filter)
                            {
                                filteredList.Add(num);
                            }
                        }
                    }
                    else if (condition == "<=")
                    {
                        foreach (var num in list)
                        {
                            if (num <= filter)
                            {
                                filteredList.Add(num);
                            }
                        }
                    }

                    string filteredOutput = string.Join(" ", filteredList);
                    Console.WriteLine(filteredOutput);
                    break;
            }

            input = Console.ReadLine();
        }

        if (changesMade == true)
        {
            string outPut = string.Join(" ", list);
            Console.WriteLine(outPut);
        }
    }
}