using System;

public class Program
{
    public static void Main()
    {
        string text = Console.ReadLine().ToLower();
        string term = Console.ReadLine().ToLower();

        int occurances = 0;

        int currentIndex = 0;

        while (currentIndex <= text.Length -1)
        {
            currentIndex = text.IndexOf(term, currentIndex);
            if (currentIndex < 0)
            {
                Console.WriteLine(occurances);
                Environment.Exit(0);
            }
            else
            {
                occurances++;
                currentIndex++;
            }
        }
        Console.WriteLine(occurances);
    }
}
