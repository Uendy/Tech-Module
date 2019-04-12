using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You will be given two hands of cards, which will be integer numbers. 
        //Assume that you have two players. You have to find out the winning deck and respectively the winner.

        //You start from the beginning of both hands. 
        //Compare the cards from the first deck to the cards from the second deck.
        //The player, who has the bigger card, takes both cards and puts them at the back of his hand 
        //the second player’s card is last, and the first person’s card(the winning one) is before it (second to last)
        //and the player with the smaller card must remove the card from his deck. 
        //If both players’ cards have the same values - no one wins,
        //and the two cards must be removed from the decks.
        //The game is over, when one of the decks is left without any cards.
        //You have to print the winner on the console and the sum of the left cards
        //"Player {one/two} wins! Sum: {sum}".

        var firstHand = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var secondHand = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        bool keepGoing = true;
        while (keepGoing == true)
        {
            var firstPlayerCard = firstHand[0];
            var secondPlayerCard = secondHand[0];

            if (firstPlayerCard > secondPlayerCard)
            {
                firstHand.Add(firstPlayerCard);
                firstHand.Add(secondPlayerCard);
            }
            else if (secondPlayerCard > firstPlayerCard)
            {
                secondHand.Add(secondPlayerCard);
                secondHand.Add(firstPlayerCard);
            }

            firstHand.RemoveAt(0);
            secondHand.RemoveAt(0);


            bool emptyHand = firstHand.Count() == 0 || secondHand.Count() == 0;
            if (emptyHand == true)
            {
                keepGoing = false;
            }
        }

        if (secondHand.Count() == 0)
        {
            Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
        }
        else
        {
            Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
        }
    }
}