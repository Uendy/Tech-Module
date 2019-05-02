using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program, which receives a string array (space-separated),
        //containing bytes in hexadecimal format with the digits reversed.

        //Your task is to remove any elements whose length is different than 2, then reverse the digits in every number,
        //and finally reverse the whole collection and convert every element from hexadecimal numbers to
        //characters from the ASCII table.

        //Print the resulting string of ASCII characters on the console.

        var input = Console.ReadLine().Split(' ').Where(x => x.Length == 2).ToArray().Reverse(); // reads input and deletes all that are not 2 in Length

        string outPut = string.Empty;
        foreach (var charAsByte in input)
        {
            string reversed = new string(charAsByte.Reverse().ToArray());
            outPut += Convert.ToChar(Convert.ToUInt32(reversed, 16)).ToString();
        }

        Console.WriteLine(outPut);
    }
}