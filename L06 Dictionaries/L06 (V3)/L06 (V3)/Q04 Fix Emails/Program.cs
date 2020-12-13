using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: You are given a sequence of strings, each on a new line, until you receive the “stop” command. The first string is the name of a person. On the second line, you will receive their email. Your task is to collect their names and emails, and remove emails whose domain ends with "us" or "uk" (case insensitive). Print:
        // { name} – > { email}

        // Example:
        //     Input                                 Output
        //     Ivan                           Ivan -> ivanivan@abv.bg
        // ivanivan @abv.bg              Petar Ivanov -> petartudjarov @abv.bg
        //  Petar Ivanov
        // petartudjarov @abv.bg
        //  Mike Tyson
        //  myke@gmail.us
        //     stop
        #endregion

        // Initialzing dict
        var emails = new Dictionary<string, string>();

        // Reading input and Cycling
        string name = Console.ReadLine();

        while (name != "stop")
        {
            string email = Console.ReadLine();

            bool wrongDomain = email.Contains(".uk") || email.Contains(".UK") || email.Contains(".us") || email.Contains(".US");
            if (!wrongDomain)
            {
                // acceptable domain, add into dict
                emails[name] = email;
            }

            // repeat cycle
            name = Console.ReadLine();
        }

        // Print all
        foreach (var kvp in emails)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }
    }
}