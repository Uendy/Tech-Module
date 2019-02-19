using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // I did another version of this for Telerik test
        var firstWordArray = Console.ReadLine().ToArray().OrderBy(x => x).ToArray();
        var firstWord = new string(firstWordArray);
        var secondWordArray = Console.ReadLine().ToArray().OrderBy(x => x).ToArray();
        var secondWord = new string(secondWordArray);

        Console.WriteLine(firstWord.Equals(secondWord));

    }
}
