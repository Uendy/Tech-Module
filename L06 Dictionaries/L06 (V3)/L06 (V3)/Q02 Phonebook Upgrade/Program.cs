using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instuctions: Add functionality to the phonebook from the previous task to print all contacts ordered lexicographically when receive the command “ListAll”.

        // Example: Input                       Output 
        // A Nakov +359888001122            Gero-> 5559393
        // A RoYaL(Ivan) 666            Nakov-> + 359888001122
        // A Gero 5559393                   RoYaL(Ivan)-> 666
        // A Simo 02 / 987665544        Simo-> 02 / 987665544
        // ListAll
        // END 
        #endregion

        var phoneBook = new Dictionary<string, string>();

        var input = Console.ReadLine().Split(' ').ToList();
        var command = input[0];

        while (command != "End")
        {
            switch (command)
            {
                case "A":
                    string name = input[1];
                    string number = input[2];

                    phoneBook[name] = number;
                    break;

                case "S":
                    string searchedName = input[1];

                    bool containsContact = phoneBook.ContainsKey(searchedName);
                    if (containsContact)
                    {
                        Console.WriteLine($"{searchedName} -> {phoneBook[searchedName]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {searchedName} does not exist.");
                    }
                    break;

                case "ListAll":
                    foreach (var kvp in phoneBook)
                    {
                        Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                    }
                    break;
            }

            input = Console.ReadLine().Split(' ').ToList();
            command = input[0];
        }
    }
}