using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //You are given a list of words in one line. 
        //Randomize their order and print each word at a separate line.

        var listOfWords = Console.ReadLine().Split(' ').ToList();

        for (int index = 0; index < listOfWords.Count(); index++)
        {
            var random = new Random();
            int randomNum = random.Next(index, listOfWords.Count());
            Console.WriteLine(listOfWords[randomNum]);
        }
    }
}