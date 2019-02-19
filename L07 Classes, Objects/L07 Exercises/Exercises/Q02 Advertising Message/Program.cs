using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Advertising_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOutputs = int.Parse(Console.ReadLine());

            string[] phrases =  {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." };

            string[] events = {
                " Now I feel good.",
                " I have succeeded with this product.",
                " Makes miracles.I am happy of the results!",
                " I cannot believe but now I feel awesome.",
                " Try it yourself, I am very satisfied.",
                " I feel great!"};
                  
            string[] author = {
                " Diana -",
                " Petya -",
                " Stella -",
                " Elena -",
                " Katya -",
                " Iva -",
                " Annie -",
                " Eva -"};

            string[] cities = {
                " Burgas",
                " Sofia",
                " Plovdiv",
                " Varna",
                " Ruse"};

            Random rnd = new Random();

            for (int i = 0; i < numberOfOutputs; i++)
            {
                string output = string.Empty;

                int phrasesPieceIndex = rnd.Next(0, phrases.Length);
                string phrasesPiece = phrases[phrasesPieceIndex];
                output += phrasesPiece;

                int eventsPieceIndex = rnd.Next(0, events.Length);
                string eventsPiece = events[eventsPieceIndex];
                output += eventsPiece;

                int authorPieceIndex = rnd.Next(0, author.Length);
                string authorPiece = author[authorPieceIndex];
                output += authorPiece;

                int cityPieceIndex = rnd.Next(0, cities.Length);
                string cityPiece = cities[cityPieceIndex];
                output += cityPiece;

                Console.WriteLine(output);
            }

        }
    }
}
