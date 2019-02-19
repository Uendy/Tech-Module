using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfTeams = int.Parse(Console.ReadLine());

        var listOfTeams = new List<Team>();
        var listOfTeamCreators = new List<string>();
        var listOfMembers = new List<string>();

        string input = Console.ReadLine();
        while (input != "end of assignment")
        {
            string member = string.Empty;
            string teamName = string.Empty;

            string seperator = "->";
            bool sorter = input.Contains(seperator);
            if (sorter == true) // wants to join a team
            {
                var inputTokens = input
                    .Split(new[] { seperator },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                member = inputTokens[0];
                teamName = inputTokens[1];

                bool teamExists = false;
                foreach (var team in listOfTeams)
                {
                    if (team.teamName == teamName)
                    {
                        teamExists = true;
                    }
                }
                if (teamExists == true)
                {
                    bool userIsNotYetInATeam = !listOfMembers.Contains(member);
                    if (userIsNotYetInATeam == true)
                    {
                        Team currentTeam;
                        foreach (var team in listOfTeams)
                        {
                            if (team.teamName == teamName)
                            {
                                currentTeam = team;
                                currentTeam.listOfMembers.Add(member);
                                listOfMembers.Add(member);
                            }
                        }
                    }
                    else // already in a team
                    {
                        Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    }
                }
                else // team does not exist
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }


            }
            else // wants to make a team
            {
                var inputTokens = input
                    .Split('-')
                    .ToList();
                member = inputTokens[0];
                teamName = inputTokens[1];

                bool teamAlreadyExists = false;
                foreach (var team in listOfTeams)
                {
                    if (team.teamName == teamName)
                    {
                        teamAlreadyExists = true;
                    }
                }
                if (teamAlreadyExists == true)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    input = Console.ReadLine();
                    continue;
                }

                bool creatorHasAlreadyMadeATeam = listOfTeamCreators.Contains(member);
                if (creatorHasAlreadyMadeATeam == true)
                {
                    Console.WriteLine($"{member} cannot create another team!");
                    input = Console.ReadLine();
                    continue;
                }


                var currentTeam = new Team();
                currentTeam.teamName = teamName;
                currentTeam.creator = member;
                listOfTeamCreators.Add(member);
                listOfMembers.Add(member);
                currentTeam.listOfMembers = new List<string>();

                Console.WriteLine($"Team {currentTeam.teamName} has been created by {currentTeam.creator}!");
                listOfTeams.Add(currentTeam);

            }


            input = Console.ReadLine();
        }

        var listOfDisbandedTeams = new List<string>();
        foreach (var team in listOfTeams)
        {
            bool noMembers = team.listOfMembers.Count == 0;
            if (noMembers == true)
            {
                listOfDisbandedTeams.Add(team.teamName);
                //listOfTeams = listOfTeams.Remove(team);
            }
        }

        listOfTeams = listOfTeams.OrderByDescending(Team => Team.listOfMembers.Count).ThenBy(T => T.teamName).ToList(); // good
        foreach (var team in listOfTeams)
        {
            bool teamDisbanded = listOfDisbandedTeams.Contains(team.teamName);
            if (teamDisbanded == true)
            {
                continue;
            }

            Console.WriteLine(team.teamName);
            Console.WriteLine($"- {team.creator}");
            team.listOfMembers = team.listOfMembers.OrderBy(member => member).ToList(); // good
            foreach (var member in team.listOfMembers)
            {
                Console.WriteLine($"-- {member}");
            }
        }

        Console.WriteLine("Teams to disband:");
        listOfDisbandedTeams = listOfDisbandedTeams.OrderBy(x => x).ToList();
        bool teamsToDisband = listOfDisbandedTeams.Count > 0;
        if (teamsToDisband == true)
        {
            foreach (var team in listOfDisbandedTeams)
            {
                Console.WriteLine(team);
            }
        }
    }
}

