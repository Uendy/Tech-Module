using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program, which reads a list of integers from the console and receives commands, which manipulate the list.
        //Your program may receive the following commands: 
        //•	Delete { element} – delete all elements in the array, which are equal to the given element.
        //•	Insert { element} { position} – insert an element and the given position.
        //You should stop the program when you receive the command "end".Print the numbers in the array separated by a single whitespace.

        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        string command = Console.ReadLine();
        while (command != "end")
        {
            var commandTokens = command.Split(' ').ToList();
            if (commandTokens[0] == "Delete")
            {
                int deleteThisElem = int.Parse(commandTokens[1]);
                if (list.Contains(deleteThisElem))
                {
                    list.RemoveAll(x => x == deleteThisElem);
                }
            }
            else if (commandTokens[0] == "Insert")
            {
                int insertedNum = int.Parse(commandTokens[1]);
                int indexOfNum = int.Parse(commandTokens[2]);

                list.Insert(indexOfNum, insertedNum);
            }

            command = Console.ReadLine();
        }

        string outPut = string.Join(" ", list);
        Console.WriteLine(outPut);
    }
}