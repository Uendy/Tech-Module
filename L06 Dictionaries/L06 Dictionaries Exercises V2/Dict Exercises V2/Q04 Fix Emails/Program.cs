using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        //You are given a sequence of strings, each on a new line, until you receive the “stop” command.
        //The first string is the name of a person.On the second line, you will receive their email.
        //Your task is to collect their names and emails
        //remove emails whose domain ends with "us" or "uk"(case insensitive).
        //Print: {name} –> {email}

        var emails = new Dictionary<string, string>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "stop")
            {
                break;
            }
            string name = input;
            string emailAddress = Console.ReadLine();

            bool improperSuffix = emailAddress.Contains(".us") || emailAddress.Contains(".uk");
            if (improperSuffix == false)
            {
                emails[name] = emailAddress;
            }
        }

        foreach (var item in emails.Keys)
        {
            Console.WriteLine($"{item} -> {emails[item]}");
        }
    }
}