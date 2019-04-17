using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that receives some info from the console about people and their phone numbers. 
        //Each entry should have just one name and one number(both of them strings). 

        //On each line, you will receive some of the following commands:
        //•	A { name} { phone} – adds entry to the phonebook.
        //In case of trying to add a name that is already in the phonebook you should change the existing phone number with the new one provided.
        //•	S { name} – searches for a contact by given name and prints it in format "{name} -> {number}".
        //In case the contact isn't found, print "Contact {name} does not exist.".
        //•	END – stop receiving more commands.

        var phoneBook = new SortedDictionary<string, string>();

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "END")
            {
                break;
            }
            else if (command == "ListAll")
            {
                foreach (var item in phoneBook.Keys)
                {
                    Console.WriteLine($"{item} -> {phoneBook[item]}");
                }

                continue;
            }

            string name = string.Empty;
            string number = string.Empty;

            var commandTokens = command.Split(' ').ToArray();

            name = commandTokens[1];

            if (commandTokens[0] == "A") //add
            {
                number = commandTokens[2];

                phoneBook[name] = number;
            }
            else // commandTokens[0] == "S" // search 
            {
                bool alreadyContainsName = phoneBook.ContainsKey(name);
                if (alreadyContainsName == true)
                {
                    Console.WriteLine($"{name} -> {phoneBook[name]}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
            }
        }
    }
}

