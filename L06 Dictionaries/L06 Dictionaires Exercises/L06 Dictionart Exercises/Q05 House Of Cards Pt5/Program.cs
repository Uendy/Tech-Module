using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_House_Of_Cards_p4
{
    class Program
    {
        static void Main(string[] args)
        {
            // could have just split by ':' first and into name - handOfCards
            // then a second split in each with (' ', ',')
            var dictionaryOfPlayersAndHands = new Dictionary<string, List<string>>();
            var scoreKeeper = new Dictionary<string, int>();

            for (int i = 0; i < 100; i++)
            {
                var input = Console.ReadLine() // my mistake here is if the name has a " " like pesho peshev: it will bug
                    .Split(' ', ',')
                    .Distinct()
                    .ToList();

                input.Remove("");  //no idea why these pop up

                if (input[0] == "JOKER")
                {
                    break;
                }

                // you must check if there are two names before the dots ':'
                string dotContainer = "";
                foreach (var item in input)
                {
                    bool containsDots = item.Contains(':');
                    if (containsDots == true)
                    {
                        dotContainer = item;
                        break;
                    }
                }

                bool twoNames = false;
                if (dotContainer == input[0])
                {
                    // then all is right.
                }
                else if (dotContainer == input[1])
                {
                   twoNames = true;
                }

                var listOfCurrentPlayersHand = new List<string>();
                if (twoNames == false)
                {
                    for (int indexOfCardInHand = 1; indexOfCardInHand < input.Count; indexOfCardInHand++)
                    {
                        listOfCurrentPlayersHand.Add(input[indexOfCardInHand]);
                    }
                }
                else if (twoNames == true)
                {
                    for (int indexOfCardInHand = 2; indexOfCardInHand < input.Count; indexOfCardInHand++)
                    {
                        listOfCurrentPlayersHand.Add(input[indexOfCardInHand]);
                    }
                }
                

                bool containsNameAlready = dictionaryOfPlayersAndHands.ContainsKey(input[0]);
                if (containsNameAlready == true)
                {
                    var result = dictionaryOfPlayersAndHands[input[0]].Concat(listOfCurrentPlayersHand).ToList();
                    dictionaryOfPlayersAndHands[input[0]] = result;
                }
                else
                {
                    dictionaryOfPlayersAndHands[input[0]] = listOfCurrentPlayersHand;
                    scoreKeeper[input[0]] = 0;
                }


            }

            var uniqueValueDict = new Dictionary<string, List<string>>();
            foreach (var person in dictionaryOfPlayersAndHands.Keys)
            {
                uniqueValueDict[person] = dictionaryOfPlayersAndHands[person].Distinct().ToList();
            }

            foreach (var person in dictionaryOfPlayersAndHands.Keys)
            {
                int sum = 0;
                string currentPlayersName = person;

                var currentPlayersHand = uniqueValueDict[currentPlayersName];

                foreach (var card in uniqueValueDict[currentPlayersName])
                {
                    var arrayOfCurrentCard = card.ToArray();

                    int multiplier = 0; // the paint a.k.a (S, H, D, C)
                    int cardNumber = 0;

                    if (arrayOfCurrentCard[0] == '1' && arrayOfCurrentCard[1] == '0') // the 10 is weird since it's not a single char
                    {
                        cardNumber = 10;
                        switch (arrayOfCurrentCard[2])
                        {
                            case 'C':
                                multiplier = 1;
                                sum += multiplier * cardNumber;
                                break;

                            case 'D':
                                multiplier = 2;
                                sum += multiplier * cardNumber;
                                break;

                            case 'H':
                                multiplier = 3;
                                sum += multiplier * cardNumber;
                                break;

                            case 'S':
                                multiplier = 4;
                                sum += multiplier * cardNumber;
                                break;
                        }
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
                            sum += multiplier * cardNumber;
                            break;

                        case 'D':
                            multiplier = 2;
                            sum += multiplier * cardNumber;
                            break;

                        case 'H':
                            multiplier = 3;
                            sum += multiplier * cardNumber;
                            break;

                        case 'S':
                            multiplier = 4;
                            sum += multiplier * cardNumber;
                            break;
                    }

                }
                scoreKeeper[currentPlayersName] += sum;

            }

            foreach (var item in scoreKeeper)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }


    }
}
