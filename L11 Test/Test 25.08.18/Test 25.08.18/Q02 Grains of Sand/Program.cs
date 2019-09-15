using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //You are given all the grains of each sand watch in a sequence on a single line, separated by spaces. 

        //After that, you will receive commands that modify the grains in a different way: 

        //O "Add {value}" - you have to add { value} to the end of the sequence.

        //O "Remove {value}" - you have to remove the first element in the sequence with value equal to { value}. 
        //If there is no such element you have to check if { value} is a valid index and remove the element at that index. Else you should ignore that command. 

        //O "Replace {value} {replacement}" you have to find the first occurrence of the element equal to { value} and replace its value with the { replacement}.
        //If element equal to { value} doesn’t exists in the sequence you have to ignore this command.

        //O "Increase {value}" you have to find the first element with value not less than { value} and increase the value of all elements in the sequence with its value.
        //If no such element exists in the sequence, you have to take the last element from the sequence and then increase the value of all elements in the sequence with its value.

        //O "Collapse {value}" you have to remove from the sequence every element with value less than { value}, if there are such elements.

        //When you receive command "Mort" you have to print the modified sequence and end the program.
        #endregion

        var list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        string input = Console.ReadLine();
        while (input != "Mort")
        {
            var commandTokens = input.Split(' ').ToList();
            string command = commandTokens[0];

            switch (command)
            {
                case "Add":
                    list = AddCommand(list, commandTokens);
                    break;

                case "Remove":
                    list = RemoveCommand(list, commandTokens);
                break;

                case "Replace":
                    list = ReplaceCommand(list, commandTokens);
                    break;

                case "Increase":
                    list = IncreaceCommand(list, commandTokens);
                    break;

                case "Collapse":
                    list = CollapseCommand(list, commandTokens);
                    break;

                default:
                    break;
            }

            input = Console.ReadLine();
        }

        string outPut = string.Join(" ", list);
        Console.WriteLine(outPut);
    }

    //O "Collapse {value}" you have to remove from the sequence every element with value less than { value}, if there are such elements.
    public static List<int> CollapseCommand(List<int> list, List<string> commandTokens)
    {
        int value = int.Parse(commandTokens[1]);
        list.RemoveAll(x => x < value);

        return list;
    }

    //O "Increase {value}" you have to find the first element with value not less than { value} and increase the value of all elements in the sequence with its value.
    //If no such element exists in the sequence, you have to take the last element from the sequence and then increase the value of all elements in the sequence with its value.
    public static List<int> IncreaceCommand(List<int> list, List<string> commandTokens)
    {
        int value = int.Parse(commandTokens[1]);
        bool numHigherThanValue = list.Any(x => x >= value);

        int incrament = 0;

        if (numHigherThanValue)
        {
            var higherValue = list.Find(x => x >= value);

            incrament = higherValue;
        }
        else
        {
            incrament = list.Last();
        }

        for (int index = 0; index < list.Count(); index++)
        {
            list[index] += incrament;
        }

        return list;
    }

    //O "Replace {value} {replacement}" you have to find the first occurrence of the element equal to { value} and replace its value with the { replacement}.
    //If element equal to { value} doesn’t exists in the sequence you have to ignore this command.
    public static List<int> ReplaceCommand(List<int> list, List<string> commandTokens)
    {
        int value = int.Parse(commandTokens[1]);
        int replacement = int.Parse(commandTokens[2]);

        int indexOfValue = list.IndexOf(value);

        bool valueContained = indexOfValue != -1;
        if(valueContained)
        {
            list[indexOfValue] = replacement;
        }

        return list;
    }

    //O "Remove {value}" - you have to remove the first element in the sequence with value equal to { value}. 
    //If there is no such element you have to check if { value} is a valid index and remove the element at that index. Else you should ignore that command. 
    public static List<int> RemoveCommand(List<int> list, List<string> commandTokens)
    {
        int value = int.Parse(commandTokens[1]);

        bool valueContained = list.IndexOf(value) != -1 ;
        if(valueContained)
        { 
            list.Remove(value);
            return list;
        }

        bool valueAsIndex = value >= 0 && value < list.Count();
        if (valueAsIndex)
        {
            list.RemoveAt(value);
        }

        return list;
    }

    //O "Add {value}" - you have to add { value} to the end of the sequence.
    public static List<int> AddCommand(List<int> list, List<string> commandTokens)
    {
        int value = int.Parse(commandTokens[1]);
        list.Add(value);

        return list;
    }
}