using System;

public class Program
{
    public static void Main()
    {
        //A marketing company wants to keep record of its employees. Each record would have the following characteristics:
        //•	First name
        //•	Last name
        //•	Age(0...100)
        //•	Gender(m or f)
        //•	Personal ID number(e.g. 8306112507)
        //•	Unique employee number(27560000…27569999)
        //Declare the variables needed to keep the information for a single employee using appropriate primitive data types. 
        //Use descriptive names.Print the data at the console.

        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        char gender = char.Parse(Console.ReadLine());
        long numbedOfID = long.Parse(Console.ReadLine());
        int employeeNumber = int.Parse(Console.ReadLine());

        Console.WriteLine($"First name: {firstName}");
        Console.WriteLine($"Last name: {lastName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Gender: {gender}");
        Console.WriteLine($"Personal ID: {numbedOfID}");
        Console.WriteLine($"Unique Employee number: {employeeNumber}");

    }
}
