using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10_Serbian_CleanedUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();

            string[] tokens = input.Split(' ').ToArray();

            bool notEnoughTokens = tokens.Length < 4; // atleast 4 tokens: Artist/ Venue/ Price/ Count
            if (notEnoughTokens == true)
            {
                InvalidInput(out input);
            }

            while (input != "End")
            {
                bool onlyOneA = input.Contains(" @");
                if (onlyOneA == false)
                {
                    InvalidInput(out input);
                    continue;
                }

                string[] otherTokens = input.Split('@').ToArray();

                string artist = otherTokens[0];
                char lastCharInArtist = artist.ToCharArray().Last();
                if (lastCharInArtist != ' ') // makes sure there is a space after artist name
                {
                    InvalidInput(out input);
                    continue;
                }

                bool artistNameTooLong = artist.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length > 3; //! why?
                if (artistNameTooLong == true)
                {
                    InvalidInput(out input);
                    continue;
                }

                long ticketPrice = 0;
                long ticketCount = 0;

                string[] venueAndTickets = otherTokens[1].Split(' ').ToArray();
                int elementsInOtherTokens = venueAndTickets.Length;
                bool notEnoughElements = elementsInOtherTokens < 3;
                if (notEnoughElements == true)
                {
                    InvalidInput(out input);
                    continue;
                }

                bool succesfullyParse = false;
                if (long.TryParse(venueAndTickets[elementsInOtherTokens - 2], out ticketPrice) && long.TryParse(venueAndTickets[elementsInOtherTokens - 1], out ticketCount))
                {
                    succesfullyParse = true;
                }

                if (succesfullyParse == false)
                {
                    InvalidInput(out input);
                    continue;
                }

                long revenue = ticketCount * ticketPrice;

                string venue = string.Empty;
                for (int index = 0; index < elementsInOtherTokens - 2; index++)
                {
                    if (index >= 5)
                    {
                        InvalidInput(out input);
                        continue;
                    }

                    bool lastIndex = index == elementsInOtherTokens - 3;
                    if (lastIndex == true)
                    {
                        venue += venueAndTickets[index];
                    }
                    else
                    {
                        venue += venueAndTickets[index] + ' ';
                    }
                }

                bool newVenue = !dict.ContainsKey(venue);
                if (newVenue)
                {
                    dict[venue] = new Dictionary<string, long>();
                    dict[venue].Add(artist, revenue);
                }
                else
                {
                    bool newArtist = !dict[venue].ContainsKey(artist);
                    if (newArtist == true)
                    {
                        dict[venue].Add(artist, revenue);
                    }
                    else // already have had this artist at this venue
                    {
                        dict[venue][artist] += revenue;
                    }
                }
                 
                // USE IN BONUS BIT FOR NOTES
                //if (!result.ContainsKey(place))
                //{
                //    result[place] = new Dictionary<string, long>();
                //}
                //if (result[place].ContainsKey(singerName))
                //{
                //    result[place][singerName] += item.Value;
                //}
                //else
                //{
                //    result[place][singerName] = item.Value;
                //}

                input = Console.ReadLine();
            }

            foreach (var item in dict.Keys)
            {
                Console.WriteLine(item);
                foreach (var kvp in dict[item].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp.Key}-> {kvp.Value}");
                }
            }
        }

        static string InvalidInput(out string input)
        {
            input = Console.ReadLine();
            return input;
        }
    }
}
