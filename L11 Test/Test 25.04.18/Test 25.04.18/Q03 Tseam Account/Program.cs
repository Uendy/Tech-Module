using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // check the question here: https://judge.softuni.bg/Contests/Practice/Index/997#0

        #region
        //As a gamer, Pesho has Tseam Account. He loves to buy new games.

        //You are given Pesho`s account with all of his games-> strings, separated by space. Until you receive "Play!"
        //you will be receiving commands which Pesho does with his account.
        //You may receive the following commands:
        //•	Install { game}
        //•	Uninstall { game}
        //•	Update { game}
        //•	Expansion { game}-{ expansion}

        //If you receive Install command, you should add the game at last position in the account, but only if it isn`t installed already.
        //If you receive Uninstall command, delete the game if it exists.
        //If you receive Update command, you should update the game if it exists and place it on last position.
        //If you receive Expansion command, check if the game exists and insert after it the expansion in the following format: "{game}:{expansion}";
        #endregion

        var games = Console.ReadLine().Split(' ').ToList();

        string input = Console.ReadLine();
        while (input != "Play!")
        {
            var commandTokens = input.Split(' ').ToList();

            string command = commandTokens[0];
            string game = commandTokens[1];

            switch (command)
            {
                case "Install":
                    games = InstallCommand(games, game);
                    break;

                case "Uninstall":
                    games = UninstallCommand(games, game);
                    break;

                case "Update":
                    games = UpdateCommand(games, game);
                    break;

                case "Expansion":
                    var expansionTokens = game.Split('-').ToArray(); // splitting the game from the expansion
                    game = expansionTokens[0];
                    string expansionName = expansionTokens[1];

                    games = ExpansionCommand(games, game, expansionName);
                    break;
            }

            input = Console.ReadLine();
        }

        string output = string.Join(" ", games);
        Console.WriteLine(output);
    }

    //checks if the game is in the list of games
    public static bool CheckIfGameExists(List<string> games, string game)
    {
        bool alreadyExists = games.Contains(game);
        return alreadyExists;
    }


    //Install command: you should add the game at last position in the account, but only if it isn`t installed already.
    public static List<string> InstallCommand(List<string> games, string game )
    {
        bool alreadyExists = CheckIfGameExists(games, game);
        if (!alreadyExists)
        {
            games.Add(game);
        }

        return games;
    }


    //Uninstall command: delete the game if it exists.
    public static List<string> UninstallCommand(List<string> games, string game)
    {
        bool alreadyExists = CheckIfGameExists(games, game);
        if (alreadyExists)
        {
            games.Remove(game);
        }

        return games;
    }


    //Update command: you should update the game if it exists and place it on last position.
    public static List<string> UpdateCommand(List<string> games, string game)
    {
        bool exists = CheckIfGameExists(games, game);
        if (exists)
        {
            games.Remove(game); // removes it from whatever index it is on
            games.Add(game);  // adds it back at the last index
        }

        return games;
    }


    //Expansion command: check if the game exists and insert after it the expansion in the following format: "{game}:{expansion}";
    public static List<string> ExpansionCommand(List<string> games, string game, string expansionName)
    {
        bool exists = CheckIfGameExists(games, game);
        if (exists)
        {
            string fullName = $"{game}:{expansionName}";

            int indexOfGame = games.IndexOf(game);
            games.Insert(indexOfGame + 1, fullName);
        }

        return games;
    }
}