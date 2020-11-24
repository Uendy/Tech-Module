using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a program, which reads a list of integers from the console and receives commands, which manipulate the list. Your program may receive the following commands: 
        //  •	Delete { element} – delete all elements in the array, which are equal to the given element
        //  •	Insert { element} { position} – insert element and the given position
        // You should stop the program when you receive the command Odd or Even.If you receive Odd  print all odd numbers in the array separated with single whitespace, otherwise print the even numbers.

        // Example: 
        //     Input                Output
        // 1 2 3 4 5 5 5 6           1 3
        //  Delete 5
        //  Insert 10 1
        //  Delete 5
        //  Odd
        #endregion

        // Reading input:
        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        // Read instruction:
        var commandLine = Console.ReadLine().Split(' ').ToArray();
        string command = commandLine[0];

        while (command != "Odd" && command != "Even")
        {
            // Read Current command and execute:
            switch (command)
            {
                case "Delete":
                    int numToDelete = int.Parse(commandLine[1]);
                    list.RemoveAll(x => x == numToDelete);
                    break;

                case "Insert":
                    int numberToInsert = int.Parse(commandLine[1]);
                    int index = int.Parse(commandLine[2]);
                    list.Insert(index, numberToInsert);
                    break;

                default:
                    break;
            }

            commandLine = Console.ReadLine().Split(' ').ToArray();
            command = commandLine[0];
        }

        // Depending on Odd/Even print the remaining elements:
        if (command == "Odd")
        {
            list = list.Where(x => x % 2 != 0).ToList();
        }
        else // even
        {
            list = list.Where(x => x % 2 == 0).ToList();
        }

        Console.WriteLine(string.Join(" ", list));
    }
}