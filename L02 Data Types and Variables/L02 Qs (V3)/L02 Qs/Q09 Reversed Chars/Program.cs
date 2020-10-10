using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Write a program to ask the user for 3 letters and print them in reversed order.

        // Example:
        // Input     Output
        //   A        CBA
        //   B
        //   C

        // Reading input:
        char firstChar = char.Parse(Console.ReadLine());
        char secondChar = char.Parse(Console.ReadLine());
        char thirdChar = char.Parse(Console.ReadLine());

        // Printing output:
        Console.WriteLine($"{thirdChar}{secondChar}{firstChar}");
    }
}