using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Create a method that takes two strings as arguments
        ///return the sum of their character codes multiplied (multiply str1.charAt (0) with str2.charAt (0) and add to the total sum). 
        //Then continue with the next two characters.
        //If one of the strings is longer than the other, add the remaining character codes to the total sum without multiplication.

        string input = Console.ReadLine();

        var chars = input
             .Select(c => (int)c)
             .Select(c => $@"\u{c:x4}");

        var result = string.Concat(chars);

        Console.WriteLine(result);
    }
}