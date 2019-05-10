using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //To model a book library, define classes to hold a book and a library. 
        //The library must have a name and a list of books. The books must contain the title, author, publisher, release date, ISBN-number and price. 

        //Read a list of books, add them to the library and print the total sum of prices by author,
        //ordered descending by price and then by author’s name lexicographically.
        //Books in the input will be in format { title}{ author}{ publisher}{ release date}{ ISBN}{ price}.
        var authorAndPrice = new Dictionary<string, double>();

        var Library = new Library();
        Library.ListOfBooks = new List<Book>();

        int numberOfInputs = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfInputs; i++)
        {
            var inputTokens = Console.ReadLine().Split(' ').ToList();

            var Book = new Book();
            Book.Title = inputTokens[0];
            Book.Author = inputTokens[1];
            Book.Publisher = inputTokens[2];
            Book.Date = inputTokens[3];
            Book.ISBN = long.Parse(inputTokens[4]);
            Book.Price = double.Parse(inputTokens[5]);

            bool newAuthor = !authorAndPrice.ContainsKey(Book.Author);
            if (newAuthor)
            {
                authorAndPrice[Book.Author] = Book.Price;
            }
            else
            {
                authorAndPrice[Book.Author] += Book.Price;
            }

            Library.ListOfBooks.Add(Book);
        }

        //Sort by : descending by price and then by author’s name lexicographically.
        authorAndPrice = authorAndPrice.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

        foreach (var author in authorAndPrice.Keys)
        {
            Console.WriteLine($"{author} -> {authorAndPrice[author]:f2}");
        }
    }
}