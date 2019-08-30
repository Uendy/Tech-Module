using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        #region
        //On the first line, you will receive a list with all participants that applied for performance. 
        //On the second line, you will receive the list with all available songs. 
        //On the next lines, until the "dawn" command, you will get the names of people, the song that they are performing on stage 
        //and the award they get from the audience.

        //However, not every time the plan goes according to schedule.In other words, everyone(listed or not) can go on stage 
        //and perform a song that is not even available and he still gets awards from the audience.
        //However, you should record only the awards for listed participants that perform songs available in the list.
        //In case someone is not listed or sings a song that is not available you should not record neither the participant, nor his award.

        //When the "dawn" comes, you need to print all participants, the count of the unique awards they received and all unique awards.
        //Participants should be sorted by number of awards in descending order and then by participant name alphabetically.
        //Awards should be sorted in alphabetical order.
        #endregion

        var awardedSingers = new List<Singer>();

        var singers = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string separator = ", ";
        var songs = Console.ReadLine().Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string input = Console.ReadLine();
        while (input != "dawn")
        {
            var inputTokens = input.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string singerName = inputTokens[0];
            string songPerformed = inputTokens[1];
            string award = inputTokens[2];

            bool validSinger = singers.Contains(singerName);
            bool validSong = songs.Contains(songPerformed);

            bool validAward = validSinger && validSong;
            if (validAward)
            {
                bool alreadyAwarded = awardedSingers.Any(x => x.Name == singerName);
                if (alreadyAwarded) // find currentArtist, update his listOfAwards with new award
                {
                    var currentSinger = awardedSingers.Find(x => x.Name == singerName);
                    currentSinger.Awards.Add(award);
                }
                else // create currentArtist object and initialize his listOfAwards and add award
                {
                    var currentSinger = new Singer()
                    {
                        Name = singerName,
                        Awards = new List<string>()
                    };

                    currentSinger.Awards.Add(award);

                    awardedSingers.Add(currentSinger);
                }
            }

            input = Console.ReadLine();
        }

        //sort and put all output in an SB and see if string comes out empty, if yes -> "No awards"
        var sb = new StringBuilder();

        var result = awardedSingers.OrderByDescending(x => x.Awards.Distinct().Count()).ThenBy(y => y.Name);

        foreach (var currentSinger in result)
        {
            sb.AppendLine($"{currentSinger.Name}: {currentSinger.Awards.Distinct().Count()}");
            foreach (var award in currentSinger.Awards.Distinct().OrderBy(x => x))
            {
                sb.AppendLine($"--{award}");
            }
        }

        string outPut = sb.ToString();

        bool noAwards = outPut == string.Empty;
        if (noAwards)
        {
            Console.WriteLine("No awards");
        }
        else
        {
            Console.WriteLine(outPut);
        }
    }
}