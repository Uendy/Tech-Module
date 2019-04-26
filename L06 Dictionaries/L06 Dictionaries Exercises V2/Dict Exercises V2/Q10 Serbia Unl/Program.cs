using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //On each input line you’ll be given data in format: "singer @venue ticketsPrice ticketsCount". 
        //There will be no redundant whitespaces anywhere in the input. 
        //Aggregate the data by venue and by singer. For each venue, print the singer and the total amount of money
        //his /her concerts have made on a separate line.
        //Venues should be kept in the same order they were entered;
        //the singers should be sorted by how much money they have made in descending order.
        //If two singers have made the same amount of money, keep them in the order in which they were entered. 

        //Keep in mind that if a line is in incorrect format, it should be skipped and its data should not be added to the output.
        //Each of the four tokens must be separated by a space, everything else is invalid.
        //The venue should be denoted with @ in front of it, such as @Sunny Beach
        //SKIP THOSE: Ceca @Belgrade125 12378, Ceca @Belgrade12312 123
        //The singer and town name may consist of one to three words. 

        //TODO: fix the last outer for-each cycle
        //ToDo: If two singers have made the same amount of money, keep them in the order in which they were entered. 

        var venueSingerRevenue = new Dictionary<string, Dictionary<string, long>>();
        //outerDict: key == venue value == innerDict
        //innerDict: key == artist value == revenue

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            var inputTokens = input.Split(' ').ToList();
            if (inputTokens.Count() < 4 || !input.Contains('@')) //SKIP THOSE
            {
                continue;
            }

            //getting all the singer names
            var singerNames = input.Split('@').First().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var singer = string.Join(" ", singerNames);

            inputTokens = inputTokens.Except(singerNames).ToList();

            //getting the ticket details
            inputTokens.Reverse();

            var ticketDetails = inputTokens.Take(2).ToArray();
            int ticketCount = int.Parse(ticketDetails[0]);
            int ticketPrice = int.Parse(ticketDetails[1]);
            long ticketRevenue = ticketPrice * ticketCount;

            inputTokens = inputTokens.Except(ticketDetails).ToList();
            inputTokens.Reverse();

            //getting all the venue names
            string venue = string.Join(" ", inputTokens).Replace("@", "");

            //inserting all the values into the dictionary venueSingerRevenue
            bool newVenue = !venueSingerRevenue.ContainsKey(venue);
            if (newVenue)
            {
                venueSingerRevenue[venue] = new Dictionary<string, long>();
            }

            bool newArtist = !venueSingerRevenue[venue].ContainsKey(singer);
            if (newArtist)
            {
                venueSingerRevenue[venue][singer] = ticketRevenue;
            }
            else
            {
                venueSingerRevenue[venue][singer] += ticketRevenue;
            }
        }

        //printing 
        foreach (var venue in venueSingerRevenue.Keys)
        {
            Console.WriteLine(venue);
            foreach (var artist in venueSingerRevenue[venue].OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {artist.Key} -> {artist.Value}");
            }
        }
    }
}