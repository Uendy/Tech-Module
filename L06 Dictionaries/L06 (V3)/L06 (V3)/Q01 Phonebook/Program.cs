using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a program that receives some info from the console about people and their phone numbers. Each entry should have just one name and one number (both of them strings). 
        // On each line, you will receive some of the following commands:
        // •	A { name} { phone} – adds entry to the phonebook.In case of trying to add a name that is already in the phonebook you should change the existing phone number with the new one provided.
        // •	S { name} – searches for a contact by given name and prints it in format "{name} -> {number}".In case the contact isn't found, print "Contact {name} does not exist.".
        // •	END – stop receiving more commands.

        #endregion

        // Initialize dict
        var phoneBook = new Dictionary<string, string>();

        // Read input commands
        var input = Console.ReadLine().Split(' ').ToList();
        string command = input[0];

        while (command != "END")
        {
            switch (command)
            {
                case "A":
                    //
                    break;

                case "S":
                    // 
                    break
    
            }
            input = Console.ReadLine().Split(' ').ToList();
            command = input[0];
        }
    }
}