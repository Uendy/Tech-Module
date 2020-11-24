using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: On the first line, you will receive a list of integers. On the next line, you will receive an array with exactly three numbers. First number represents the number of elements you have to take from the list (starting from the first one). Second number represents the number of elements you have to delete from the numbers you took (starting from the first one). Last number is the number we search in our collection after the manipulations. If it is present print: “YES!”, otherwise print “NO!”

        // Example: 
        //              Input                         Output
        //12 412 123 21 654 34 65 3 23                 NO!
        //             7 4 21
        #endregion

        // Reading input:
        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var commands = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        // Getting commands
        int take = commands[0];
        int delete = commands[1];
        int search = commands[2];

        // Begin list manipulatons:
        list = list.Take(take).ToList();
        list.RemoveRange(0, delete);
        bool containsSearch = list.Contains(search);

        // Printing depending on check
        if (containsSearch)
        {
            Console.WriteLine("YES!");
        }
        else
        {
            Console.WriteLine("NO!");
        }

    }
}