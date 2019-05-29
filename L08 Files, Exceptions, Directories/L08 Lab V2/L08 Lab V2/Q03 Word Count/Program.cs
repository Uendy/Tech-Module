using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

public class Program
{
    public static void Main()
    {
        //Write a program that reads a list of words from the file words.txt
        //find how many times each of the words is contained in another file text.txt.Matching should be case-insensitive.
        // The result should be written to another text file.Sort the words by frequency in descending order. 

        var wordsFile = "words.txt";
        var inputFile = "inputText.txt";

        var searchedWords = File.ReadAllText(wordsFile.ToLower()).Split(' ');

        var inputWords = File.ReadAllText(inputFile.ToLower())
            .Split(new[] { ' ', ',', '.', '!', '?', '-', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ToLower());

        var wordCount = new Dictionary<string, int>();

        foreach (var word in inputWords)
        {
            bool isSearchedWord = searchedWords.Contains(word);
            if (isSearchedWord)
            {
                bool newWord = !wordCount.ContainsKey(word);
                if (newWord)
                {
                    wordCount[word] = 1;
                }
                else
                {
                    wordCount[word]++;
                }
            }
        }

        //Kenov Solution:
        //  var sortedDictionary = wordCount
        //      .OrderByDescending(kvp => kvp.Value)
        //      .Select(kvp => $"{kvp.Key} - {kvp.Value}")
        //      .ToArray();
        //  File.WriteAllLines("result.txt", sortedDictionary);


        // sort dictionary descending
        wordCount = wordCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

        var sb = new StringBuilder();
        foreach (var kvp in wordCount)
        {
            sb.AppendLine($"{kvp.Key} - {kvp.Value}");
        }

        var outPut = sb.ToString();

        var outPutFile = "result.txt";
        File.WriteAllText(outPutFile, outPut);
    }
}