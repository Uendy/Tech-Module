using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //You will be given information about results of football matches. Create a standings table by points.
        //For win the team gets 3 points, for loss – 0 and for draw – 1.Also find the top 3 teams with most scored goals in descending order.
        //If two or more teams are with same goals scored or same points order them by name in ascending order.

        //The name of each team is encrypted.You must decrypt it before proceeding with calculating statistics.
        //You will be given some string key and the team name will be placed between that key in reversed order.

        //For example: the key: “???”;
        //String to decrypt: “kfle ??? airagluB ??? gertIt %%” -> “airagluB” -> “Bulgaria”
        //Also you should ignore the letter casing in the team names.For example:
        //buLgariA = BulGAria = bulGARIA = BULGARIA

        //Input / Constrains
        //•	On the first line of input you will get the key that will be used for decryption
        //•	On the next lines until you receive “final” you will get lines in format:
        //{ encrypted teamA} { encrypted teamB} { teamA score}:{ teamB score}
        //•	Team scores will be integer numbers in the range[0...231]
        #endregion

        var listOfTeams = new List<Team>();

        string encryptionKey = Console.ReadLine();

        string input = Console.ReadLine();
        while (input != "final")
        {
            var inputTokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string firstTeamName = DecypherTeamName(encryptionKey, inputTokens[0]);
            string secondTeamName = DecypherTeamName(encryptionKey, inputTokens[1]);

            var firstTeam = new Team();
            firstTeam.Name = firstTeamName;
            bool firstExists = listOfTeams.Any(x => x.Name == firstTeamName);
            if (firstExists)
            {
                 firstTeam = listOfTeams.Find(x => x.Name == firstTeamName);
            }

            var secondTeam = new Team();
            secondTeam.Name = secondTeamName;
            bool secondExists = listOfTeams.Any(x => x.Name == secondTeamName);
            if (secondExists)
            {
                secondTeam = listOfTeams.Find(x => x.Name == secondTeamName);
            }

            var score = inputTokens[2].Split(':').Select(int.Parse).ToArray();
            if (score[0] == score[1]) // draw
            {
                firstTeam.Goals += score[0];
                firstTeam.Points += 1;

                secondTeam.Goals += score[0];
                secondTeam.Points += 1;
            }
            else if (score[0] > score[1]) // 1 wins
            {
                firstTeam.Goals += score[0];
                firstTeam.Points += 3;

                secondTeam.Goals += score[1];
            }
            else //2 wins
            {
                firstTeam.Goals += score[0];

                secondTeam.Goals += score[1];
                secondTeam.Points += 3;
            }

            //update them
            listOfTeams.Remove(firstTeam);
            listOfTeams.Add(firstTeam);

            listOfTeams.Remove(secondTeam);
            listOfTeams.Add(secondTeam);

            input = Console.ReadLine();
        }

        //ordering and printing
        var standings = listOfTeams.OrderByDescending(x => x.Points).ThenBy(x => x.Name).ToList();
        Console.WriteLine("League standings:");
        for (int index = 0; index < standings.Count(); index++)
        {
            var currentTeam = standings[index];
            Console.WriteLine($"{index + 1}. {currentTeam.Name} {currentTeam.Points}");
        }

        var topScorers = listOfTeams.OrderByDescending(x => x.Goals).ThenBy(x => x.Name).Take(3).ToList();
        Console.WriteLine("Top 3 scored goals:");
        foreach (var team in topScorers)
        {
            Console.WriteLine($"- {team.Name} -> {team.Goals}");
        }
    }

    public static string DecypherTeamName(string encryptionKey, string currentTeam)
    {
        int pos1 = currentTeam.IndexOf(encryptionKey) + encryptionKey.Length;
        int pos2 = currentTeam.Substring(pos1).IndexOf(encryptionKey);
        currentTeam = currentTeam.Substring(pos1, pos2);

        char[] charArray = currentTeam.ToCharArray();
        Array.Reverse(charArray);
        currentTeam = new string(charArray).ToUpper();

        return currentTeam;
    }
}