using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a method that takes as input two strings, and returns Boolean if they are exchangeable or not.
        //Exchangeable are words where the characters in the first string can be replaced to get the second string.
        //Example: "egg" and "add" are exchangeable, but "aabbccbb" and "nnooppzz" are not.
        //(First 'b' corresponds to 'o', but then it also corresponds to 'z').
        //The two words may not have the same length, if such is the case they are 
        //exchangeable only if the longer one doesn't have more types of characters then the shorter one 
        //("Clint" and "Eastwaat" are exchangeable because 'a' and 't' are already mapped as 'l' and 'n', but "Clint" 
        //"Eastwood" aren't exchangeable because 'o' and 'd' are not contained in "Clint").

        var input = Console.ReadLine().Split(' ').ToArray();
        var firstString = new string(input[0].ToCharArray().Distinct().ToArray());
        var secondString = new string(input[1].ToCharArray().Distinct().ToArray());

        if (firstString.Length != secondString.Length) 
        {
            Console.WriteLine("false");
        }
        else // Magic Number
        {
            Console.WriteLine("true");
        }

    }
}