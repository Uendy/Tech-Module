using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
namespace SP_HighScore
{
    public class Program
    {
        public static void Main()
        {
            // this is a side project
            //// program to keep track of the top 5 highest scores
            //// kept in a dictionary in a file in the Hard disk.

            //read the file
            string inputFile = "saveFile.txt";
            var scores = File.ReadAllLines(inputFile);

            //convert to dictionary
            var playersAndScores = new Dictionary<string, long>();  // key = name, value = score
            foreach (var line in scores)
            {
                var tokens = line.Split('-').ToArray();

                var name = tokens[0];
                var points = long.Parse(tokens[1]);

                playersAndScores[name] = points;
            }

            //read the points currently achieved
            Console.Write("How many points did you get? : ");
            long currentScore = long.Parse(Console.ReadLine());

            //read name of player
            Console.Write("Please input name : ");
            string playerName = Console.ReadLine();
             
            //add into dictionary 
            playersAndScores[playerName] = currentScore;
            playersAndScores = playersAndScores.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            //check to see if less than five, if no -> keep only highest 5 scores
            bool tooManyScores = playersAndScores.Keys.Count() >= 5;
            if(tooManyScores)
            {
                playersAndScores = playersAndScores.Take(5).ToDictionary(x => x.Key, y => y.Value);
            }

            //write all the names and scores in one string 
            var sb = new StringBuilder();
            foreach (var kvp in playersAndScores)
            {
                var currentLine = $"{kvp.Key}-{kvp.Value}";
                sb.AppendLine(currentLine);
            }

            string output = sb.ToString();

            File.WriteAllText(inputFile, output);

            //see if you should display the scores or not
            Console.WriteLine("Would you like to see the champion?");
            Console.Write("yes/no? : ");
            string command = Console.ReadLine().ToLower();

            int position = 1;

            bool displayScores = command == "yes";
            if (displayScores)
            {
                foreach (var champion in playersAndScores)
                {
                    Console.WriteLine($"{position++}. {champion.Key} - {champion.Value}");
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}