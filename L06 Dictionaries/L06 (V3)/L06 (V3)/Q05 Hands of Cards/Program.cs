using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: 
        //  You are given a sequence of people and for every person what cards he draws from the deck.The input will be separate lines in the format:
        //  •	{ personName}: { PT, PT, PT,… PT}
        //  Where P(2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A) is the power of the card and T(S, H, D, C) is the type. The input ends when a "JOKER" is drawn.The name can contain any ASCII symbol except ':'.The input will always be valid and in the format described, there is no need to check it.
        //  A single person cannot have more than one card with the same power and type, if they draw such a card they discard it.The people are playing with multiple decks.Each card has a value that is calculated by the power multiplied by the type. Powers 2 to 10 have the same value and J to A are 11 to 14.Types are mapped to multipliers the following way(S-> 4, H-> 3, D-> 2, C-> 1).
        //  Finally print out the total value each player has in his hand in the format:
        //  •	{ personName}: { value}
        #endregion

        // Initialize score (key = name, value = hand)
        var playersAndHands = new Dictionary<string, List<string>>();

        // Reading input
        string input = Console.ReadLine();
        while (input != "JOKER")
        {
            // Get the hand and add them to the people
            var hand = input.Split(':').ToArray();
            string name = hand[0];
            var hands = hand[1];

            // Get cards
            var cards = hands.Split(new string[] { ", " }, StringSplitOptions.None).Select(s => s.Trim()).ToList();

            // Add or Update players with new hands
            bool newPlayer = !playersAndHands.ContainsKey(name);
            if (newPlayer)
            {
                playersAndHands[name] = cards;
            }
            else
            {
                playersAndHands[name].InsertRange(0, cards);
            }

            // Continue reading input and cycling
            input = Console.ReadLine();
        }

        // remove duplicates and calculate score
        foreach (var kvp in playersAndHands)
        {
            var uniqueCards = kvp.Value.Distinct();

            int score = 0;
            foreach (var card in uniqueCards)
            {
                char power = card.First(); // 2 to A
                char type = card.Last(); //S = 4, H = 3, D = 2, C = 1

                var cardScore = FindScore(power, type);
                score += cardScore;
            }

            Console.WriteLine($"{kvp.Key}: {score}");
        }
    }
    public static int FindScore(char power, char type)
    {
        int score = 0;

        switch (power)
        {
            case '2':
                score = 2;
                break;

            case '3':
                score = 3;
                break;

            case '4':
                score = 4;
                break;

            case '5':
                score = 5;
                break;

            case '6':
                score = '6';
                break;

            case '7':
                score = 7;
                break;

            case '8':
                score = 8;
                break;

            case '9':
                score = 9;
                break;

            case '1':           // No need for 0 as there is no '1' card --> its a 10
                score = 10;
                break;

            case 'J':
                score = 11;
                break;

            case 'Q':
                score = 12;
                break;

            case 'K':
                score = 13;
                break;

            case 'A':
                score = 14;
                break;

            default:
                break;
        }
        switch (type)
        {
            case 'S':
                score *= 4;
                break;

            case 'H':
                score *= 3;
                break;

            case 'D':
                score *= 2;
                break;

            case 'C':
                score *= 1;
                break;

            default:
                break;
        }

        return score;
    }
}