using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that takes a text and a string of banned words. 
        //All words included in the ban list should be replaced with asterisks "*", equal to the word's length.
        //The entries in the ban list will be separated by a comma and space ", ".
        //The ban list should be entered on the first input line and the text on the second input line.

        var bannedWords = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var bannedWordsAndLengths = new Dictionary<string, int>(); ////key = word //value = .length
        foreach (var word in bannedWords)
        {
            bannedWordsAndLengths[word] = word.Length;
        }

        var inputText = Console.ReadLine();

        foreach (var word in bannedWordsAndLengths.Keys)
        {
            var censor = new string('*', bannedWordsAndLengths[word]);
            inputText = inputText.Replace(word, censor.ToString());
        }

        Console.WriteLine(inputText);
    }
}