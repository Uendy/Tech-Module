using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10_Serbian_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, long>();

            var input = Console.ReadLine();

            while (!input.Contains('@') || input[input.IndexOf('@') - 1] != ' ')
            {
                input = Console.ReadLine();
            }
            while (input != "End")
            {

                var inputTokens = input // Lepa Brena @Sunny Beach 25 3500
                    .Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries)        // artist   @ Place, Ticket price, tickets sold
                    .ToList();
                if (inputTokens[0] == input || inputTokens[1].Length < 3) // if no @ => wrong input
                {
                    input = Console.ReadLine();
                    continue;
                }

                string artist = inputTokens[0];

                var otherTokens = inputTokens[1]
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList(); // venue / price / sales

                bool skipLine = otherTokens.Count <= 2; // check for invalid input
                if (skipLine == true)
                {
                    input = Console.ReadLine();
                    continue;
                }
                int countOfTokensForVenueName = otherTokens.Count - 2; // finding length of venueName

                string venueName = "";
                for (int index = 0; index < countOfTokensForVenueName; index++)
                {
                    bool lastIndex = index == countOfTokensForVenueName - 1; // to see where to put " "
                    if (lastIndex == true)
                    {
                        venueName += otherTokens[index];
                    }
                    else
                    {
                        venueName += otherTokens[index] + " ";
                    }

                }

                // Check if there's another @
                bool anotherAt = false;
                for (int i = 1; i < venueName.Length; i++)
                {
                    if (venueName[i].Equals(new char[] { '@', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }))
                    {
                        anotherAt = true;
                        break;
                    }
                }
                if (anotherAt)
                {
                    input = Console.ReadLine();
                    continue;
                }
                venueName = venueName.TrimStart('@');

                bool moreThanThreeWords = artist.Count() > 3 && venueName.Count() > 3;
                if (moreThanThreeWords == false)
                {
                    input = Console.ReadLine();
                    continue;
                }

                //bool venueContainsDigit = false;
                //foreach (var charecter in venueName)
                //{
                //    if (char.IsDigit(charecter))
                //    {
                //        venueContainsDigit = true;
                //    }
                //}

                //if (venueContainsDigit == true)
                //{
                //    input = Console.ReadLine();
                //    continue;
                //}


                long currentConcertRevenue = 0;
                if (long.TryParse(otherTokens.Last(), out long ticketSales) && (long.TryParse(otherTokens[otherTokens.Count - 2], out long ticketPrice)))
                {
                    currentConcertRevenue = ticketPrice * ticketSales;
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (currentConcertRevenue == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                // adding into dictionary 
                var key = venueName + "/" + artist;
                //dict1[venue + artist] = money
                bool newVenueAndArtist = !dict.ContainsKey(key);
                if (newVenueAndArtist == true)
                {
                    dict[key] = currentConcertRevenue;
                }
                else // already have them
                {
                    dict[key] += currentConcertRevenue;
                }

                input = Console.ReadLine();
            }
            

            var result = new Dictionary<string, Dictionary<string, long>>(); // new more sorted dictionary

            foreach (var item in dict)
            {
                var keys = item.Key.ToString().Split('/').ToList();


                bool newVenue = result.ContainsKey(keys[0]);
                if (newVenue == false) // add the venue into result
                { 
                    result[keys[0]] = new Dictionary<string, long>();
                    bool newArtist = result[keys[0]].ContainsKey(keys[1]);
                    if (newArtist == false)
                    {
                        result[keys[0]].Add(keys[1], item.Value);
                    }
                    else
                    {
                        result[keys[0]][keys[1]] += item.Value;
                    }
                }
                else 
                {
                    bool newArtist = result[keys[0]].ContainsKey(keys[1]);
                    if (newArtist == false) // add artist
                    {
                        result[keys[0]].Add(keys[1], item.Value);
                    }
                    else
                    {
                        result[keys[0]][keys[1]] += item.Value;
                    }
                }
            }

            foreach (var venuePair in result)
            {
                Console.WriteLine($"{venuePair.Key}");

                foreach (var singerPair in result[venuePair.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key)) //as per  the Money value
                {
                    Console.WriteLine($"#  {singerPair.Key}-> {singerPair.Value}"); //mind your spaces
                }
            }
        }
    }
}
