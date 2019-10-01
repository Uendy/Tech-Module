using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        int decoder = int.Parse(Console.ReadLine());

        var names = new List<string>();

        string namePattern = @"@([A-z] +).*\!G\!"; // group 1 == the name
        //@"@([a-z]|[A-Z])+";
        //string goodListPattern = @"!G!";

        string input = Console.ReadLine();
        while (input != "end")
        {

            input = Console.ReadLine();
        }

        foreach (var kid in names)
        {
            Console.WriteLine(kid);
        }

    }
}