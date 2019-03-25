using System;
public class Program
{
    public static void Main()
    {
        //Write a program that creates an array containing all letters from the alphabet (a-z).
        //Read a lowercase word from the console and print the index of each of its letters in the letters array.
        string input = Console.ReadLine();
        var inputAsArray = input.ToCharArray();

        foreach (var letter in inputAsArray)
        {
            int letterAsIndex = letter - 'a'; 
            Console.WriteLine($"{letter} -> {letterAsIndex}");
        }
    }
}