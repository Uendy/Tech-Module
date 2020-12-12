using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: You are given a sequence of strings, each on a new line. Every odd line on the console is representing a resource (e.g. Gold, Silver, Copper, and so on), and every even – quantity. Your task is to collect the resources and print them each on a new line. 
        // Print the resources and their quantities in format:
        // { resource} –> { quantity}
        // The quantities inputs will be in the range[1 … 2 000 000 000]

        // Example:
        // Input              Output  
        // Gold              Gold -> 155
        //  155              Silver-> 10
        // Silver            Copper-> 17
        //  10
        // Copper
        //  17
        // stop 
        #endregion

        // Initialize Dictionary
        var resources = new Dictionary<string, int>();

        // Read input and cycle them, while also not trying to read value input after "stop"
        string resource = Console.ReadLine();
        while (resource != "stop")
        {
            int value = int.Parse(Console.ReadLine());

            // Check for new key and add value accordingly
            bool newResource = resources.ContainsKey(resource);
            if (newResource)
            {
                resources[resource] += value;
            }
            else
            {
                resources[resource] = value;
            }

            resource = Console.ReadLine();
        }

        // Printing all output
        foreach (var kvp in resources)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }
    }
}