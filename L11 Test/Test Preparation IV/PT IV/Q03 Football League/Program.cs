using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
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

        string encryptionKey = Console.ReadLine();
        // make a class Team

        string input = Console.ReadLine().ToUpper();
        while (input != "FINAL")
        {

            input = Console.ReadLine().ToUpper();
        }
    }
}