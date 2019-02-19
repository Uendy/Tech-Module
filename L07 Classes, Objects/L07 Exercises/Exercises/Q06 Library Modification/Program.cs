using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        var Library = new Library();
        Library.Dictionary = new SortedDictionary<string, DateTime>();

        int numberOfInputs = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfInputs; i++)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string title = input[0];
            DateTime published = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);

            var Book = new Book2();
            Book.Title = title;
            Book.PublicationDate = published;

            Library.Dictionary[title] = published;
        }

        string cutOffAsString = Console.ReadLine();
        var cutOffDate = DateTime.ParseExact(cutOffAsString, "dd.MM.yyyy", CultureInfo.InvariantCulture);

        var dictOfAfterCutOff = new Dictionary<string, DateTime>(); // temptDict

        foreach (var currentBook in Library.Dictionary)
        {
            bool releasedBeforeCutOff = currentBook.Value <= cutOffDate;
            if (releasedBeforeCutOff == false)
            {
                dictOfAfterCutOff[currentBook.Key] = currentBook.Value;
            }
        }

        var resultDict = dictOfAfterCutOff.OrderBy(date => date.Value).ThenBy(title => title.Key);
        foreach (var book in resultDict)
        {
            Console.WriteLine($"{book.Key} -> {book.Value:dd.MM.yyyy}");
        }
    }
}
