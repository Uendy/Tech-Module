using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a list of words from the file words.txt 
        //and finds how many times each of the words is contained in another file text.txt 
        //Matching should be case-insensitive.
        //Write the results in file results.txt.Sort the words by frequency in descending order.

        var wordsFile = "inputWords.txt";
        var searchedWords = File.ReadAllText(wordsFile).Split(' ').ToArray();

        var textFile = "textFile.txt";
        var fullText = File.ReadAllText(textFile).Split(' ').ToArray();

        var wordsAndFrequency = new Dictionary<string, int>();

        foreach (var word in fullText)
        {
            bool isSearchedWord = searchedWords.Contains(word);
            if (isSearchedWord)
            {
                bool notInDictionary = !wordsAndFrequency.ContainsKey(word);
                if (notInDictionary)
                {
                    wordsAndFrequency[word] = 0;
                }

                wordsAndFrequency[word]++;
            }
        }

        wordsAndFrequency = wordsAndFrequency.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

        File.WriteAllText("output.txt", string.Empty);

        foreach (var word in wordsAndFrequency.Keys)
        {
            File.AppendAllText("output.txt", $"{word} - {wordsAndFrequency[word]} \r\n");
        }
    }
}