using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You are given a sequence of people and for every person what cards he draws from the deck. 
        //The input will be separate lines in the format:

        //•	{ personName}: { PT, PT, PT,… PT} 
        //Where P(2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A) is the power of the card and
        //T(S, H, D, C) is the type. The input ends when a "JOKER" is drawn.The name can contain any ASCII symbol except ':'.
        //The input will always be valid and in the format described, there is no need to check it.
        //A single person cannot have more than one card with the same power and type, if they draw such a card they discard it.
        //The people are playing with multiple decks.Each card has a value that is calculated by the power multiplied by the type.
        //Powers 2 to 10 have the same value and J to A are 11 to 14.Types are mapped to multipliers the following way(S-> 4, H-> 3, D-> 2, C-> 1).
        //Finally print out the total value each player has in his hand in the format:
        //•	{ personName}: { value}

        var dictOfCards = new Dictionary<string, int>();

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "JOKER")
            {
                break;
            }

            string inputSeperator = ": ";
            var inputTokens = input.Split(new string[] { inputSeperator }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string name = inputTokens[0];

            string separator = ", ";
            var hand = inputTokens[1].Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).ToList();

            int handTotal = HandCalculator(hand);

            bool newPlayer = !dictOfCards.ContainsKey(name);
            if (newPlayer == true)
            {
                dictOfCards[name] = handTotal;
            }
            else
            {
                dictOfCards[name] += handTotal;
            }
        }

        foreach (var item in dictOfCards.Keys)
        {
            Console.WriteLine($"{item}: {dictOfCards[item]}");
        }
    }

    public static int HandCalculator(List<string> hand)
    {
        int handTotal = 0;

        hand = hand.Distinct().ToList(); //if they draw such a card they discard it. The people are playing with multiple decks.

        foreach (var card in hand)
        {
            int currentTotal = 0;
            var valueValue = 0;
            var colorValue = 0;

            if (card.Contains("10"))
            {
                valueValue = 10;
            }
            else
            {
                char value = card.First();
                switch (value)
                {
                    case '2':
                        valueValue = 2;
                        break;

                    case '3':
                        valueValue = 3;
                        break;

                    case '4':
                        valueValue = 4;
                        break;

                    case '5':
                        valueValue = 5;
                        break;

                    case '6':
                        valueValue = 6;
                        break;

                    case '7':
                        valueValue = 7;
                        break;

                    case '8':
                        valueValue = 8;
                        break;

                    case '9':
                        valueValue = 9;
                        break;

                    case 'J':
                        valueValue = 11;
                        break;

                    case 'Q':
                        valueValue = 12;
                        break;

                    case 'K':
                        valueValue = 13;
                        break;

                    case 'A':
                        valueValue = 14;
                        break;
                }
            }

            char color = card.Last();
            switch (color)
            {
                //S-> 4, H-> 3, D-> 2, C-> 1
                case 'C':
                    colorValue = 1;
                    break;

                case 'D':
                    colorValue = 2;
                    break;

                case 'H':
                    colorValue = 3;
                    break;

                case 'S':
                    colorValue = 4;
                    break;
            }

            currentTotal = valueValue * colorValue;
            handTotal += currentTotal;
        }

        return handTotal;
    }
}