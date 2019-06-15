using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    //Check any questions here: https://judge.softuni.bg/Contests/Practice/Index/320#0
    public static void Main()
    {
        //Write a program that reads a string from the console, reverses it and prints the result back at the console.

        string input = Console.ReadLine();
        input = new string(input.ToCharArray().Reverse().ToArray());
        Console.WriteLine(input);

    }
}