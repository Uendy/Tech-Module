using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_House_Of_Cards_p2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictOfPlayers = new Dictionary<string, List<string>>();

            var scoreKeeper = new Dictionary<string, int>();

            var listOfPlayersNames = new List<string>();

            string input = Console.ReadLine();

            bool theEnd = input == "JOKER";
            while (theEnd == false)
            {
                var breakingDownInput = input // [0] = player name, [1]....[n] = cards
                   .Split(' ', ',')
                   .Distinct()
                   .ToList();

                breakingDownInput.Remove(""); // error that gave ""

                var listOfCards = new List<string>();
                for (int index = 1; index < breakingDownInput.Count; index++)
                {
                    listOfCards.Add(breakingDownInput[index]);
                }

                bool containsKey = dictOfPlayers.ContainsKey(breakingDownInput[0]);
                if (containsKey == false)
                {
                    dictOfPlayers[breakingDownInput[0]] = listOfCards;
                    scoreKeeper[breakingDownInput[0]] = 0;
                    listOfPlayersNames.Add(breakingDownInput[0]);
                }
                else // (containsKey == true)
                {
                    dictOfPlayers[breakingDownInput[0]] = dictOfPlayers[breakingDownInput[0]].Concat(listOfCards).ToList();
                }

                input = Console.ReadLine();
                if (input == "JOKER")
                {
                    theEnd = true;
                }
            }

            var uniqueValues = dictOfPlayers
                         .ToDictionary(pair => pair.Key, pair => pair.Value.Distinct()); // this was it!

            int sum = 0;

            for (int indexOfPlayer = 0; indexOfPlayer < dictOfPlayers.Keys.Count; indexOfPlayer++)
            {
                var currentPlayersName = listOfPlayersNames[indexOfPlayer];

                for (int indexOfCard = 0; indexOfCard < dictOfPlayers[currentPlayersName].Count; indexOfCard++)
                {
                    var currentPlayersHand = uniqueValues[currentPlayersName];

                    foreach (var card in uniqueValues[currentPlayersName]) // dictOP[currentPlayersName]
                    {
                        var arrayOfCurrentCard = card.ToArray();

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
                        scoreKeeper[currentPlayersName] += sum;
                    }
                }
            }
            foreach (var item in scoreKeeper)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

        }
    }
}
