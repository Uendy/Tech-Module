using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a string from the console, reverses it and prints the result back at the console.

        string input = Console.ReadLine();
        string output = new string(input.ToCharArray().Reverse().ToArray());

        Console.WriteLine(output);
    }
}