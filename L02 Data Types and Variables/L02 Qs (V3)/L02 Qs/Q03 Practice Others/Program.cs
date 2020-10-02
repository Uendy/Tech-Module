using System;
public class Program
{
    public static void Main()
    {
        // Instructions:
        // Create a new C# project and create a program that assigns character and string values to variables. Be sure that each value is stored in the correct variable. Finally, you need to print all variables to the console.

        // Ex: 
        // Software University
        // B
        // y
        // e
        // I love programming

        // Reading input:
        string firstString = Console.ReadLine();
        char firstChar = char.Parse(Console.ReadLine());
        char secondChar = char.Parse(Console.ReadLine());
        char thirdChar = char.Parse(Console.ReadLine());
        string secondString = Console.ReadLine();

        // Printing output: 
        Console.WriteLine(firstString);
        Console.WriteLine(firstChar);
        Console.WriteLine(secondChar);
        Console.WriteLine(thirdChar);
        Console.WriteLine(secondString);
    }
}