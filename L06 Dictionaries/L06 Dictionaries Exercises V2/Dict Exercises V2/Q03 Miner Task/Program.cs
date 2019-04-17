using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        //You are given a sequence of strings, each on a new line.
        //Every odd line on the console is representing a resource (e.g. Gold, Silver, Copper, and so on) and every even – quantity.
        //Your task is to collect the resources and print them each on a new line. 
        //Print the resources and their quantities in format:
        //{ resource} –> { quantity}

        var resourceBook = new Dictionary<string, int>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "stop")
            {
                break;
            }
            int secondInput = int.Parse(Console.ReadLine());

            string material = input;
            int quantity = secondInput;

            bool alreadyInDict = resourceBook.ContainsKey(material);
            if (alreadyInDict == true)
            {
                resourceBook[material] += quantity;
            }
            else // new so add it
            {
                resourceBook[material] = quantity;
            }
        }

        foreach (var item in resourceBook.Keys)
        {
            Console.WriteLine($"{item} -> {resourceBook[item]}");
        }
    }
}