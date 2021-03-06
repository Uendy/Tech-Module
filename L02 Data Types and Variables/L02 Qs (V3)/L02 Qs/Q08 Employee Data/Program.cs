﻿using System;
public class Program
{
    public static void Main()
    {
        // Instructions: A marketing company wants to keep record of its employees. Each record would have the following characteristics:
        // •	First name
        // •	Last name
        // •	Age(0...100)
        // •	Gender(m or f)
        // •	Personal ID number(e.g. 8306112507)
        // •	Unique employee number(27560000…27569999)
        // Declare the variables needed to keep the information for a single employee using appropriate primitive data types. Use descriptive names.Print the data at the console.

        // Examples
        //  Input                       Output
        //  Amanda              First name: Amanda
        //  Jonson              Last name: Jonson
        //  27                  Age: 27
        //  f                   Gender: f
        //  8306112507          Personal ID: 8306112507
        //  27563571            Unique Employee number: 27563571

        // Reading input:
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        byte age = byte.Parse(Console.ReadLine());
        char gender = char.Parse(Console.ReadLine());
        long id = long.Parse(Console.ReadLine());
        int uniqueEmployeeNumber = int.Parse(Console.ReadLine());

        // Printing output;
        Console.WriteLine($"First name: {firstName}");
        Console.WriteLine($"Last name: {lastName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Gender: {gender}");
        Console.WriteLine($"Personal ID: {id}");
        Console.WriteLine($"Unique Employee number: {uniqueEmployeeNumber}");
    }
}