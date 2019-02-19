using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        input = new string(input.ToCharArray().Reverse().ToArray());
        Console.WriteLine(input);

        //var input = Console.ReadLine().ToCharArray();
        //input = input.Reverse().ToArray();

        //string output = string.Empty;
        //foreach (var letter in input)
        //{
        //    output += letter;
        //}

        //Console.WriteLine(output);

    }
}
