using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q09_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictOfTeams = new Dictionary<string, string>(); // key = creator, value = teamName
            var dictOfTeamsForUsers = new Dictionary<string, Dictionary<Teams,List<string>>>(); // key = teamName (string), value = teams (Teams), Innervalue = listOfUsers;
            var listOfTeams = new List<Teams>();
            var listOfUsers = new List<string>();

            int numberOfTeams = int.Parse(Console.ReadLine());
            // check if you need to stop making teams

            string input = Console.ReadLine();
            while (input != "end of assignement")
            {
                bool wantsToJoin = input.Contains("->"); // wants to join
                bool wantsToCreate = input.Contains("-"); // wants to create

                if (wantsToCreate == true)
                {
                    var inputTokens = input.Split('-').ToArray();
                    string creator = inputTokens[0];
                    string teamName = inputTokens[1];

                    bool teamAlreadyMade = dictOfTeams.ContainsValue(teamName);
                    if (teamAlreadyMade == true)
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                    }
                    else
                    {
                        // team not yet exist
                        bool userAlreadyMadeTeam = dictOfTeams.ContainsKey(creator);
                        if (userAlreadyMadeTeam == true)
                        {
                            Console.WriteLine($"{creator} cannot create another team");
                        }
                        else
                        {
                            // new creator -> make team
                            var currentTeam = new Teams();

                            currentTeam.Creator = creator;
                            currentTeam.TeamName = teamName;
                            currentTeam.ListOfMembers = new List<string>();

                            dictOfTeams[creator] = teamName;
                            dictOfTeamsForUsers[teamName] = new Dictionary<Teams, List<string>>();
                            dictOfTeamsForUsers[teamName][currentTeam] = new List<string>();
                               // currentTeam.ListOfMembers;
                            //listOfTeams.Add(currentTeam);
                        }
                    }

                }
                else // look up if 3rd option 
                {
                    // wants to join
                    var inputTokens = input.Split(new string[] {"->"}, StringSplitOptions.None).ToArray();
                    string user = inputTokens[0];
                    string desiredTeam = inputTokens[1];

                    bool teamExists = dictOfTeams.ContainsValue(desiredTeam);
                    if (teamExists == false) // dosent exist
                    {
                        Console.WriteLine($"Team {desiredTeam} does not exist!");
                    }
                    else
                    {
                        // team exists
                        bool userAlreadyInATeam = listOfUsers.Contains(user);
                        if (userAlreadyInATeam == true)
                        {
                            Console.WriteLine($"Member {user} is already in a team {desiredTeam}!");
                        }
                        else
                        {
                            // isn't already in a team

                            dictOfTeamsForUsers[desiredTeam] = new Dictionary<Teams, List<string>>();
                            dictOfTeamsForUsers[desiredTeam]
                        }
                    }
                }


                input = Console.ReadLine();
            }
        }
    }
}
