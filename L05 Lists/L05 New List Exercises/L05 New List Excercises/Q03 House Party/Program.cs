using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // Write a program that keeps track of guests, that are going to a house party.
        //On the first line of input, you are going to receive the number of commands you are going to receive.
        //On the next lines you are going to receive one of the following messages:
        //-"{name} is going!" - you have to add the person if he / she is not in the list and if he / she is in the list 
        //print on the console: "{name} is already in the list!".
        //- "{name} is not going!" - If you receive the second message, you have to remove the person if he / she is in the list
        //if not print: "{name} is not in the list!".At the end print all the guests.

        int numberOfInput = int.Parse(Console.ReadLine());

        var listOfGuests = new List<string>();

        for (int index = 0; index < numberOfInput; index++)
        {
            string input = Console.ReadLine();
            var inputTokens = input.Split(' ').ToList();
            string name = inputTokens[0];

            if (inputTokens.Contains("not"))
            {
                if (listOfGuests.Contains(name))
                {
                    listOfGuests.Remove(name);
                }
                else // not in list
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
            }
            else
            {
                if (listOfGuests.Contains(name))
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else // add to list
                {
                    listOfGuests.Add(name);
                }
            }
        }

        foreach (var guest in listOfGuests)
        {
            Console.WriteLine(guest);
        }
    }
}
