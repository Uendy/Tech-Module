using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that generate random fake advertisement message to extol some product. 

        //The messages must consist of 4 parts: laudatory phrase + event + author + city. Use the following predefined parts:
        //•	Phrases – {“Excellent product.”, “Such a great product.”, “I always use that product.”, “Best product of its category.”, “Exceptional product.”, “I can’t live without this product.”}
        //•	Events – {“Now I feel good.”, “I have succeeded with this product.”, “Makes miracles. I am happy of the results!”, “I cannot believe but now I feel awesome.”, ”Try it yourself, I am very satisfied.”, “I feel great!”}
        //•	Author – {“Diana”, “Petya”, “Stella”, “Elena”, “Katya”, “Iva”, “Annie”, “Eva”}
        //•	Cities – {“Burgas”, “Sofia”, “Plovdiv”, “Varna”, “Ruse”}

        //The format of the output message is: { phrase}{event} {author} – {city}.
        //As an input you take the number of messages to be generated.Print each random message at a separate line.

        var listOfPhrases = new List<string>(){
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can’t live without this product."
        };

        var listOfEvents = new List<string>(){
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        };

        var listOfAuthors = new List<string>() {
            "Diana",
            "Petya",
            "Stella",
            "Elena",
            "Katya",
            "Iva",
            "Annie",
            "Eva"
        };

        var listOfCities = new List<string>() {
            "Burgas",
            "Sofia",
            "Plovdiv",
            "Varna",
            "Ruse"
        };

        var rnd = new Random();

        int numberOfOutputs = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfOutputs; i++)
        {
            var currentPhraseIndex = rnd.Next(0, listOfPhrases.Count());
            var currentEventsIndex = rnd.Next(0, listOfEvents.Count());
            var currentAuthorsIndex = rnd.Next(0, listOfAuthors.Count());
            var currentCitiesIndex = rnd.Next(0, listOfCities.Count());

            Console.WriteLine($"{listOfPhrases[currentPhraseIndex]} {listOfEvents[currentEventsIndex]} {listOfAuthors[currentAuthorsIndex]} - {listOfCities[currentCitiesIndex]}");
        }
    }
}