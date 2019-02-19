using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_House_Of_Cards_Pt6
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictOfPlayersAndHands = new Dictionary<string, List<string>>();
            var scoreKeeper = new Dictionary<string, int>();


            var input = Console.ReadLine()
                .Split(':')
                .ToArray();

            while (input[0] != "JOKER")
            {
                var currentHand = input[1]
                    .Split(' ', ',')
                    .Distinct()
                    .ToList();
                currentHand.Remove("");

                bool alreadyInList = dictOfPlayersAndHands.ContainsKey(input[0]);
                if(alreadyInList == false)
                {
                    dictOfPlayersAndHands[input[0]] = currentHand; // brilliant
                    scoreKeeper[input[0]] = 0;

                }
                else // already have that key
                {
                    var result = new List<string>();
                    result = dictOfPlayersAndHands[input[0]].Concat(currentHand).Distinct().ToList();

                    dictOfPlayersAndHands[input[0]] = result;
                }

                input = Console.ReadLine().Split(':').ToArray();
            }

            foreach (var playerName in dictOfPlayersAndHands.Keys)
            {
                int sum = 0;

                var currentPlayersHand = dictOfPlayersAndHands[playerName];

                for (int card = 0; card < currentPlayersHand.Count; card++)
                {
                    
                    var currentCard = currentPlayersHand[card].ToString(); // 2C -> [0] = cardNumber [1] = multiplier
                    char cardNumber = currentCard[0]; //!
                    char multiplier = currentCard[1];

                    int cardPower;
                    int cardType;

                    bool cardIsATen = currentCard[0] == '1' && currentCard[1] == '0'; // card = 10

                    if (cardIsATen == true)
                    {
                        cardPower = 10;

                        switch (currentCard[2])
                        {
                            case 'C':
                                cardType = 1;
                                sum += cardType * cardPower;
                                break;

                            case 'D':
                                cardType = 2;
                                sum += cardType * cardPower;
                                break;

                            case 'H':
                                cardType = 3;
                                sum += cardType * cardPower;
                                break;

                            case 'S':
                                cardType = 4;
                                sum += cardType * cardPower;
                                break;
                        }
                    }
                    else if (currentCard[0] == 'J')
                    {
                        cardPower = 11;
                    }
                    else if (currentCard[0] == 'Q')
                    {
                        cardPower = 12;
                    }
                    else if (currentCard[0] == 'K')
                    {
                        cardPower = 13;
                    }
                    else if (currentCard[0] == 'A')
                    {
                        cardPower = 14;
                    }
                    else
                    {
                        cardPower = Convert.ToInt32(currentCard[0] - 48);
                    }

                    switch (currentCard[1])
                    {
                        case 'C':
                            cardType = 1;
                            sum += cardType * cardPower;
                            break;

                        case 'D':
                            cardType = 2;
                            sum += cardType * cardPower;
                            break;

                        case 'H':
                            cardType = 3;
                            sum += cardType * cardPower;
                            break;

                        case 'S':
                            cardType = 4;
                            sum += cardType * cardPower;
                            break;
                    }
                }
                scoreKeeper[playerName] += sum;
            }
            foreach (var item in scoreKeeper)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
