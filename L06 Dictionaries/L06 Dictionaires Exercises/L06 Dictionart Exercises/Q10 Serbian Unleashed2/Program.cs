using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10_Serbian_Unleashed2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Аз съм я решил със следните проверки(след като сплитнеш входния ред по спейс):
            //проверка дали input.length е поне 4 елемента;
            //проверка, дали в началото на някой от елементите има '@';
            //според това къде си намерил '@' дотам ти е artist name - след като го сглобиш го проверяваш колко е дълго(макс.позволена дължина е според условието);
            //от '@' нататък си сглобяваш venue name и пак правиш такава проверка както горе на artist name;
            //парсваш си цената и броя на билетите - ако нещо там не се случи както трябва - входа е невалиден;

            var dict = new Dictionary<string, long>();

            string input = Console.ReadLine();

            //!input.Contains('@') || input[input.IndexOf('@') - 1] != ' ' || 
            while (input.Contains(" @") == false)
            {
                input = Console.ReadLine();
                continue;
            }
            while (input != "End")
            {
                string artist = string.Empty;
                string venueName = string.Empty;
                long ticketPrice = 0;
                long ticketSales = 0;

                var otherTokens = input
                    .Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                bool containsOneA = otherTokens.Length != 2; // contains exactyly 1 '@'
                if (containsOneA == true)
                {
                    InvalidInput(out input);
                    continue;
                }

                artist = otherTokens[0]; // get artist
                
                char lastSymbol = artist.Last(); // the 80 -> 100 % checks if last char in artist is a ' ' or artist@venue (no spaces)
                if (lastSymbol != ' ')
                {
                    InvalidInput(out input);
                    continue;
                }
                //if (artist.EndsWith(" ") == false)
                //{
                //    continue;
                //}

                string[] artistSplit = artist.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                bool artistMoreThanThree = artistSplit.Length > 3;
                if (artistMoreThanThree == true)
                {
                    InvalidInput(out input);
                    continue;
                }

                // the 2 number
                string[] venueAndMoney = otherTokens[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                bool notEnoughData = venueAndMoney.Length < 3;
                if (notEnoughData == true)
                {
                    InvalidInput(out input);
                    continue;
                }

                long currentConcertRevenue = 0;
                if (long.TryParse(venueAndMoney[venueAndMoney.Length - 1], out ticketSales) && (long.TryParse(venueAndMoney[venueAndMoney.Length - 2], out ticketPrice)))
                {
                    currentConcertRevenue = ticketPrice * ticketSales;
                }
                else
                {
                    InvalidInput(out input);
                    continue;
                }

                bool lessThanThreeOtherTokens = otherTokens.Length > 3;
                if (lessThanThreeOtherTokens == true)
                {
                    InvalidInput(out input);
                    continue;
                }

                bool timeToContinue = false;
                for (int index = 0; index < venueAndMoney.Length - 2; index++)
                {
                    venueName += venueAndMoney[index] + " ";

                    if (index > 2)
                    {
                        InvalidInput(out input);
                        timeToContinue = true;
                    }
                }
                if (timeToContinue == true)
                {
                    continue;
                }
                venueName.TrimEnd(' ');

                // adding into dictionary 
                var key = venueName + "/" + artist;

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
                var keys = item.Key.ToString().Split('/').ToList(); // split the old key into venue + artist

                string place = keys[0];
                string singerName = keys[1];

                if (!result.ContainsKey(place))
                {
                    result[place] = new Dictionary<string, long>();
                }
                if (result[place].ContainsKey(singerName))
                {
                    result[place][singerName] += item.Value;
                }
                else
                {
                    result[place][singerName] = item.Value;
                }
            }

            //foreach (var venuePair in result)
            //{
            //    Console.WriteLine($"{venuePair.Key}");

            //    foreach (var singerPair in result[venuePair.Key].OrderByDescending(x => x.Value)) //as per  the Money value
            //    {
            //        Console.WriteLine($"#  {singerPair.Key}-> {singerPair.Value}"); //mind your spaces
            //    }
            //}

            foreach (KeyValuePair<string, Dictionary<string, long>> venueSingerEarning in result)
            {
                Console.WriteLine($"{venueSingerEarning.Key.TrimEnd(' ')}");
                foreach (KeyValuePair<string, long> singerEarning in venueSingerEarning.Value.OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"#  {singerEarning.Key}-> {singerEarning.Value}");
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
