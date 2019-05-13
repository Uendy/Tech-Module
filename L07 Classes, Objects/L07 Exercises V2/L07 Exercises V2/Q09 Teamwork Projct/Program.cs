using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //It's time for teamwork projects and you are responsible for making the teams.

        //First you will receive an integer - the count of the teams you will have to register.
        //You will be given a user and a team (separated with "-").  The user is the creator of that team. 
        //For every newly created team you should print a message: "Team {team Name} has been created by {user}!". 

        //Next you will receive user with team (separated with "->") which means that the user wants to join that team. 
        //Upon receiving command: "end of assignment" you should print every team ordered by members count (descending),
        //then by name (ascending). For each team you have to print it's members sorted by name (ascending).

        //However there are several rules:
        //•	If user tries to create a team more than once a message should be displayed:
        // -"Team {teamName} was already created!"
        //•	Creator of a team cannot create another team -message should be thrown:
        // -"{user} cannot create another team!"
        //•	If user tries to join currently non - existing team a message should be displayed: 
        //-"Team {teamName} does not exist!"
        //•	Member of a team cannot join another team -message should be thrown:
        // -"Member {user} cannot join team {team Name}!"
        //•	In the end(after teams' report) teams with zero members (with only a creator) should disband.  Every team to disband should be printed ordered by name (ascending) in this format:
        //- "{teamName}:- { creator}-- { member}…"

        var teams = new List<Team>();

        int numberOfTeams = int.Parse(Console.ReadLine()); //making of teams that pass every check
        for (int i = 0; i < numberOfTeams; i++)
        {
            var inputTokens = Console.ReadLine().Split('-').ToArray();
            string teamCaptain = inputTokens[0];
            string teamName = inputTokens[1];

            bool teamAlreadyExists = teams.Exists(x => x.Name == teamName);
            if (teamAlreadyExists)
            {
                Console.WriteLine($"Team {teamName} was already created!");
                continue;
            }

            bool captainAlreadyHasTeam = teams.Exists(x => x.Creator == teamCaptain);
            if (captainAlreadyHasTeam)
            {
                Console.WriteLine($"{teamCaptain} cannot create another team!");
                continue;
            }

            //make the team since passed all checks
            var currentTeam = new Team()
            {
                Name = teamName,
                Creator = teamCaptain,
                Members = new List<string>()
            };
            Console.WriteLine($"Team {teamName} has been created by {teamCaptain}!");
            teams.Add(currentTeam);
        }

        while (true) // allowing new members in
        {
            var input = Console.ReadLine();
            if (input == "end of assignment")
            {
                break;
            }

            string seperator = "->";
            var inputTokens = input.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string memberName = inputTokens[0];
            string desiredTeam = inputTokens[1];

            bool teamDosentExists = !teams.Exists(x => x.Name == desiredTeam);
            if (teamDosentExists)
            {
                Console.WriteLine($"Team {desiredTeam} does not exist!");
                continue;
            }

            bool inAnotherTeam = teams.Exists(x => x.Members.Exists(y => y == memberName)) ||
                teams.Exists(x => x.Creator == memberName);
            if (inAnotherTeam)
            {
                Console.WriteLine($"Member {memberName} cannot join team {desiredTeam}!");
                continue;
            }

            var currentTeam = teams.Find(x => x.Name == desiredTeam);
            currentTeam.Members.Add(memberName);
        }

        //printing and sorting
        var teamsToDisband = teams.FindAll(x => x.Members.Count() == 0).OrderBy(x => x.Name).ToList();
        teams = teams.OrderByDescending(x => x.Members.Count()).ThenBy(x => x.Name).ToList();
        foreach (var team in teams)
        {
            bool disband = team.Members.Count() == 0;
            if (disband)
            {
                continue;
            }
            Console.WriteLine($"{team.Name}");
            Console.WriteLine($"- {team.Creator}");
            foreach (var member in team.Members)
            {
                Console.WriteLine($"-- {member}");
            }
        }

        //teams to disband 
        Console.WriteLine("Teams to disband:");
        foreach (var team in teamsToDisband)
        {
            Console.WriteLine($"{team.Name}");
        }

    }
}