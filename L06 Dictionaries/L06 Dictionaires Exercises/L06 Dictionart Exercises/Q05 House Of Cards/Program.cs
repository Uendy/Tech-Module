using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_House_Of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictOfPlayers = new Dictionary<string, List<string>>();

            var scoreKeeper = new Dictionary<string, int>();

            string input = Console.ReadLine();

            bool theEnd = input == "JOKER";
            while (!theEnd)
            {
                var breakingDownInput = input // [0] = player name, [1]....[n] = cards
                    .Split(' ',',')
                    .Distinct()
                    .ToList();
                breakingDownInput.RemoveAt(2); // error that gave ""

                bool containsKey = dictOfPlayers.ContainsKey(breakingDownInput[0]);
                if (containsKey == false)
                {
                    dictOfPlayers[breakingDownInput[0]] = null;
                    scoreKeeper[breakingDownInput[0]] = 0;
                }

                var listOfCards = new List<string>();
                for (int index = 1; index < breakingDownInput.Count; index++)
                {
                    listOfCards.Add(breakingDownInput[index]);
                }

                dictOfPlayers[breakingDownInput[0]] = listOfCards;

                int sum = 0;
                for (int index = 0; index < listOfCards.Count; index++)
                {
                    var arrayOfCurrentCard = listOfCards[index].ToArray();

                    int multiplier = 0; // the paint a.k.a (S, H, D, C)
                    int cardNumber = 0;

                    if (arrayOfCurrentCard[0] == '1' && arrayOfCurrentCard[1] == '0') // the 10 is weird since it's not a single char
                    {
                        cardNumber = 10;
                    }
                    else if (arrayOfCurrentCard[0] == 'J')
                    {
                        cardNumber = 11;
                    }
                    else if (arrayOfCurrentCard[0] == 'Q')
                    {
                        cardNumber = 12;
                    }
                    else if (arrayOfCurrentCard[0] == 'K')
                    {
                        cardNumber = 13;
                    }
                    else if (arrayOfCurrentCard[0] == 'A')
                    {
                        cardNumber = 14;
                    }
                    else
                    {
                        cardNumber = Convert.ToInt32(arrayOfCurrentCard[0] - 48);
                    }

                    switch (arrayOfCurrentCard[1])
                    {
                        case 'C':
                            multiplier = 1;
                            sum = multiplier * cardNumber;
                            break;

                        case 'D':
                            multiplier = 2;
                            sum = multiplier * cardNumber;
                            break;

                        case 'H':
                            multiplier = 3;
                            sum = multiplier * cardNumber;
                            break;

                        case 'S':
                            multiplier = 4;
                            sum = multiplier * cardNumber;
                            break;
                    }
                    scoreKeeper[breakingDownInput[0]] += sum;
                }
                input = Console.ReadLine();
                if (input == "JOKER")
                {
                    theEnd = true;
                }
            }
            foreach (var item in scoreKeeper)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
            Environment.Exit(0);
        }

    }
}
