using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        //Check questions here: https://judge.softuni.bg/Contests/Practice/Index/320#0

        string input = Console.ReadLine();

        var result = new string(input.Reverse().ToArray());

        Console.WriteLine(result);
    }
}