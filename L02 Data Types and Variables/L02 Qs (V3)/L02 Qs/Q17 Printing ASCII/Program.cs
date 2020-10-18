using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints part of the ASCII table of characters at the console.  On the first line of input you will receive the char index you should start with and on the second line - the index of the last character you should print.

        // Example:
        // Input          Output
        //  60
        //  65          < = > ? @ A


        // Reading parameters:
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        // Cylcing and printing:
        for (int i = start; i <= end; i++)
        {
            Console.Write($"{(char)i} ");
        }

        Console.WriteLine();
    }
}