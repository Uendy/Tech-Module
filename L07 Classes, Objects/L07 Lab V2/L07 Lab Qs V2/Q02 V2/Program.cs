using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        //You are given a list of words in one line. 
        //Randomize their order and print each word at a separate line.

        var words = Console.ReadLine().Split(' ').ToList();
        var outPutWords = new List<string>();

        while (words.Count() != 0)
        {
            var random = new Random();
            var currentRandom = random.Next(0, words.Count());

            string currentWord = words[currentRandom];

            if (!outPutWords.Contains(currentWord))
            {
                words.Remove(currentWord);
                outPutWords.Add(currentWord);
            }
        }

        foreach (var word in outPutWords)
        {
            Console.WriteLine(word);
        }

    }
}