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

        var bannedWords = Console.ReadLine();
        var listOfBannedWords = bannedWords.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var dictOfBannedWords = new Dictionary<string, int>(); //key = word //value = .length
        foreach (var word in listOfBannedWords)
        {
            dictOfBannedWords[word] = word.Length;
        }

        var text = Console.ReadLine();

        foreach (var word in dictOfBannedWords.Keys)
        {
            var censor = new string('*', dictOfBannedWords[word]);
            text = text.Replace(word, censor.ToString());
        }

        Console.WriteLine(text);
    }
}