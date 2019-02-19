using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        var chars = input
            .Select(c => (int)c)
            .Select(c => $@"\u{c:x4}");

        var result = string.Concat(chars);

        Console.WriteLine(result);
    }
}
