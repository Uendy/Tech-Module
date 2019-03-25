using System;
public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        var inputAsArray = input.ToCharArray();

        foreach (var letter in inputAsArray)
        {
            int letterAsIndex = letter - 'a'; 
            Console.WriteLine($"{letter} -> {letterAsIndex}");
        }
    }
}