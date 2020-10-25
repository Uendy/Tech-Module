using System;
public class Program
{
    public static void Main()
    {
        // Instructions: 
        // Write a method that receives a name as parameter and prints on the console. “Hello, <name>!”

        // Example:
        // Input    	Output
        // Peter     Hello, Peter!

        // Reading input:
        string input = Console.ReadLine();
        NameReturner(input);
    }
    static void NameReturner(string input)
    {
        Console.WriteLine($"Hello, {input}");
    }
}