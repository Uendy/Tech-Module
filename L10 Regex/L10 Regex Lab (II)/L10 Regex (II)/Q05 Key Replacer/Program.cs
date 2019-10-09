using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        //You will be given a key string and a text string. The key string will contain a start key and an end key.

        //The start key starts at the beginning of the string and ends at the first occurrence of one of the symbols – “|”, “<” or “\”.
        //The end key starts at the last occurrence of one of these symbols and ends when the string ends. Both keys can contain only Latin alphabet letters.

        //When you extract both keys search for them in the text string and extract every string, which is between them. 
        //Concatenate all collected strings and print the result.If the result string is empty print “Empty result”.

        string key = Console.ReadLine();
        string text = Console.ReadLine();

        var keyWords = new List<string>();

        string outPut = string.Join("", keyWords);
        Console.WriteLine(outPut);
    }
}