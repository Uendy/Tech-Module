using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read a text, extract its words, find all short words (less than 5 characters) and print them alphabetically, in lowercase.
        //•	Use the following separators: . , : ; ( )[ ] " ' \ / ! ? (space).
        //•	Use case-insensitive matching.
        //•	Remove duplicated words.

        var text = Console.ReadLine()
            .ToLower()
            .Split(new[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' '}, StringSplitOptions.RemoveEmptyEntries)
            .Where(x => x.Length < 5)
            .OrderBy(x => x)
            .Distinct()
            .ToList();

        Console.WriteLine(string.Join(", ", text));



    }
}