using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //check the question here: https://judge.softuni.bg/Contests/Practice/Index/997#1
        // nested dictionary or a Class Player containing their dict[position] = skill, tried Class to train ita

        #region
        //Pesho is a pro MOBA player, he is struggling to become master of the Challenger tier.
        //So he watches carefully the statistics in the tier.

        //You will receive several input lines in one of the following formats:
        //"{player} -> {position} -> {skill}"
        //"{player} vs {player}"

        //The player and position are strings, the given skill will be an integer number.You need to keep track of every player. 

        //When you receive a player and his position and skill, add him to the player pool, if he isn`t present, 
        //else add his position and skill or update his skill, only if the current position skill is lower than the new value.

        //If you receive "{player} vs {player}" and both players exist in the tier, they duel with the following rules:
        //Compare their positions, if they got at least one in common, 
        //the player with better total skill points wins and the other is demoted from the tier -> remove him. 
        //If they have same total skill points, the duel is tie and they both continue in the Season.
        //If they don`t have positions in common, the duel isn`t happening and both continue in the Season.

        //You should end your program when you receive the command "Season end".
        //At that point you should print the players, ordered by total skill in desecending order,
        //then ordered by player name in ascending order. Foreach player print their position and skill, 
        //ordered desecending by skill, then ordered by position name in ascending order.
        #endregion

        var listOfPlayers = new List<Player>();

        string input = Console.ReadLine();
        while (input != "Season end")
        {
            var seperators = new string[] { " ", "->", "vs" };

            var inputTokens = input.Split(seperators, StringSplitOptions.RemoveEmptyEntries).ToList();

            var battle = inputTokens.Count() == 2;
            if (battle)
            {
                string firstPlayerName = inputTokens[0];
                string secondPlayerName = inputTokens[1];

                bool bothExist = listOfPlayers.Any(x => x.Name == firstPlayerName)
                    && listOfPlayers.Any(x => x.Name == secondPlayerName);
                if (bothExist) // see if they have a position in common
                {
                    var firstPlayer = listOfPlayers.Find(x => x.Name == firstPlayerName);
                    var secondPlayer = listOfPlayers.Find(x => x.Name == secondPlayerName);

                    var firstPlayerPositions = firstPlayer.Stats.Keys.ToList();
                    var secondPlayerPositions = secondPlayer.Stats.Keys.ToList();

                    bool samePosition = false;

                    foreach (var positionOne in firstPlayerPositions)
                    {
                        foreach (var positionTwo in secondPlayerPositions)
                        {
                            if (positionOne == positionTwo)
                            {
                                samePosition = true;
                                break;
                            }
                        }
                    }

                    if (samePosition)
                    {
                        int firstPlayerTotalStats = firstPlayer.Stats.Values.Sum();
                        int secondPlayerTotalStats = secondPlayer.Stats.Values.Sum();

                        if (firstPlayerTotalStats > secondPlayerTotalStats) // remove 2nd player
                        {
                            listOfPlayers.Remove(secondPlayer);
                        }
                        else if (secondPlayerTotalStats > firstPlayerTotalStats) // remove 1st player
                        {
                            listOfPlayers.Remove(firstPlayer);
                        }
                    }

                }
            }
            else // player (addition || update)
            {
                string playerName = inputTokens[0];
                string position = inputTokens[1];
                int skill = int.Parse(inputTokens[2]);

                bool newPlayer = !listOfPlayers.Any(x => x.Name == playerName);
                if (newPlayer) // adding a new player
                {
                    var currentPlayer = new Player()
                    {
                        Name = playerName,
                        Stats = new Dictionary<string, int>()
                    };

                    currentPlayer.Stats[position] = skill;

                    listOfPlayers.Add(currentPlayer);

                }
                else // see if you update old player (add new position, newer skill)
                {
                    var currentPlayer = listOfPlayers.Find(x => x.Name == playerName);

                    bool newPosition = !currentPlayer.Stats.ContainsKey(position);
                    if (newPosition)
                    {
                        currentPlayer.Stats[position] = skill;
                    }
                    else // see if higher skill and if yes -> update
                    {
                        bool higherSkill = skill > currentPlayer.Stats[position];
                        if (higherSkill)
                        {
                            currentPlayer.Stats[position] = skill;
                        }
                    }
                }
            }

            input = Console.ReadLine();
        }

        // order players by total skill, then foreach player order their skills and print

        var ranking = listOfPlayers.OrderByDescending(x => x.Stats.Values.Sum()).ThenBy(y => y.Name).ToList();

        foreach (var player in ranking)
        {
            Console.WriteLine($"{player.Name}: {player.Stats.Values.Sum()} skill");

            foreach (var kvp in player.Stats.OrderByDescending(x => x.Value).ThenBy(y => y.Key)) //key = position, value = skill
            {
                Console.WriteLine($"- {kvp.Key} <::> {kvp.Value}");
            }
        }
    }
} 