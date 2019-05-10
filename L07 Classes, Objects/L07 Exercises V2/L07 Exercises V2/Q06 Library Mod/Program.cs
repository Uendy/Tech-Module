using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
public class Program
{
    public static void Main()
    {
        //Use the classes from the previous problem and make a program that read a list of books
        //and print all titles released after given date ordered by date and then by title lexicographically.
        //The date is given if format “day-month-year” at the last line in the input.
        var Library = new Library();
        Library.ListOfBooks = new List<Book>();

        int numberOfInputs = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfInputs; i++)
        {
            var inputTokens = Console.ReadLine().Split(' ').ToList();

            var Book = new Book
            {
                Title = inputTokens[0],
                Author = inputTokens[1],
                Publisher = inputTokens[2],
                Date = inputTokens[3],
                ISBN = long.Parse(inputTokens[4]),
                Price = double.Parse(inputTokens[5])
            };

            Library.ListOfBooks.Add(Book);
        }

        var date = Console.ReadLine();
        var cutOffDate = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

        var bookAndDate = new Dictionary<string, DateTime>();
        foreach (var book in Library.ListOfBooks)
        {
            //find date and check if book is released after the cutoff
            var bookReleaseDate = DateTime.ParseExact(book.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            bool afterDate = cutOffDate < bookReleaseDate;
            if (afterDate)
            {
                bookAndDate[book.Title] = bookReleaseDate;
            }
        }

        bookAndDate = bookAndDate.OrderBy(releasedate => releasedate.Value).ThenBy(title => title.Key).ToDictionary(x => x.Key, y => y.Value);
        foreach (var book in bookAndDate.Keys)
        {
            Console.WriteLine($"{book} -> {bookAndDate[book]:dd.MM.yyyy}");
        }
    }
}