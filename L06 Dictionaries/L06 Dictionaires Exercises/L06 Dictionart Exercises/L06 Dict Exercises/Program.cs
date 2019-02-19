﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_Dict_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();

            for (int i = 0; i < 100; i++)
            {
                var input = Console.ReadLine()
                .Split(' ')
                .ToArray();

                string firstLetter = input[0];

                switch (firstLetter)
                {
                    case "A":
                        string name = input[1];
                        string number = input[2];

                        phoneBook[name] = number;
                        break;


                    case "S":
                        string searchedName = input[1];
                        bool containsKey = phoneBook.ContainsKey(searchedName);

                        if (containsKey == true)
                        {
                            Console.WriteLine($"{searchedName} -> {phoneBook[searchedName]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {searchedName} does not exist.");
                        }
                        break;


                    case "END":
                        Environment.Exit(0);
                        break;
                }

            }
        }
    }
}
