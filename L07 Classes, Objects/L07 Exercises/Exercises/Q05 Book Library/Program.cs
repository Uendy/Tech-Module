using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var dictOfAuthorsAndPrice = new Dictionary<string, double>();

        var Library = new Library();
        Library.Name = "Saint Alex's Library";
        Library.Books = new List<Books>();
        Library.Dict = new SortedDictionary<string, double>();
        //Library.Final = new Dictionary<string, double>();

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            var input = Console.ReadLine()
            .Split(' ')
            .ToArray();

            var Book = new Books();
            Book.Title = input[0];
            Book.Author = input[1];
            Book.Publisher = input[2];
            Book.RealeaseDate = input[3];
            Book.ISBN = long.Parse(input[4]);
            Book.Price = double.Parse(input[5]);

            Library.Books.Add(Book);

            bool newAuthor = !Library.Dict.ContainsKey(Book.Author);
            if (newAuthor == true)
            {
                Library.Dict[Book.Author] = Book.Price;
            }
            else // old author
            {
                Library.Dict[Book.Author] += Book.Price;
            }

        }

        var resultDict = Library.Dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
        foreach (var author in resultDict)
        {
            Console.WriteLine($"{author.Key} -> {author.Value:f2}");
        }

    }
}
