using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(' ').ToArray();

        var firstString = input[0];
        var secondString = input[1];

        Console.WriteLine(MagicExchange(firstString, secondString).ToString().ToLower());
    }

    static bool MagicExchange(string firstString, string secondString)
    {
        bool exchangable = false;

        var firstStringAsCharArray = firstString.ToCharArray().Distinct().ToArray();
        var secondStringAsCharArray = secondString.ToCharArray().Distinct().ToArray();

        if (firstStringAsCharArray.Count() == secondStringAsCharArray.Count())
        {
            exchangable = true;
        }

        return exchangable;
    }
}
