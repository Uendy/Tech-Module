using System;
using System.Linq;
public class Program
{
    public static void Main()
    {

        #region
        //You are given a collection of tickets separated by commas and spaces. 
        //You need to check every one of them if it has a winning combination of symbols.

        //A valid ticket should have exactly 20 characters.The winning symbols are '@', '#', '$' and '^'.
        //But in order for a ticket to be a winner the symbol should uninterruptedly repeat for at least 6 times
        //in both the tickets left half and the tickets right half.

        //For example, a valid winning ticket should be something like this: 
        //"Cash$$$$$$Ca$$$$$$sh"
        //The left half "Cash$$$$$$" contains "$$$$$$", which is also contained in the tickets right half "Ca$$$$$$sh"
        //.A winning ticket should contain symbols repeating up to 10 times in both halves, which is considered a Jackpot
        //(for example: "$$$$$$$$$$$$$$$$$$$$").

        //Input
        //The input will be read from the console.The input consists of a single line containing all tickets separated by commas 
        //one or more white spaces in the format:
        //•	"{ticket}, {ticket}, … {ticket}"

        //Output
        //Print the result for every ticket in the order of their appearance, each on a separate line in the format:
        //•	Invalid ticket - "invalid ticket"
        //•	No match - "ticket "{ ticket}" - no match"
        //•	Match with length 6 to 9 - "ticket "{ ticket}" - {match length}{match symbol}"
        //•	Match with length 10 - "ticket "{ ticket}" - {match length}{match symbol} Jackpot!"
        #endregion

        var tickets = Console.ReadLine()
            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToArray();

        var winningSymbols = new char[] { '$', '@', '#', '^' };

        foreach (var ticket in tickets)
        {
            string outPut = MatchTickets(ticket, winningSymbols);
            Console.WriteLine(outPut);
        }
    }

    
    public static string MatchTickets(string ticket, char[] winningSymbols)
    {
        string outPut = "invalid ticket";
        if (ticket.Length == 20)
        {
            outPut = $"ticket \"{ticket}\" - no match";

            var leftSide = ticket.Substring(0, 10); // the question requires the pattern in both halves of the ticket
            var rightSide = ticket.Substring(10, 10);

            for (int length = 10; length >= 6; length--) // sees how long the queue of symbols is
            {
                foreach (var symbol in winningSymbols)
                {
                    string subString = new string(symbol, length);
                    bool isPresentInLeft = leftSide.Contains(subString);
                    if (isPresentInLeft)
                    {
                        bool isPresentInRight = rightSide.Contains(subString);
                        if (isPresentInRight)  // winning ticket
                        {
                            bool jackPot = length == 10;
                            if (jackPot)
                            {
                                outPut = $"ticket \"{ticket}\" - 10{symbol} Jackpot!";
                                return outPut;
                            }
                            else
                            {
                                outPut = $"ticket \"{ticket}\" - {length}{symbol}";
                                return outPut;
                            }
                        }
                    }
                }
            }
        }
        return outPut;
    }
}