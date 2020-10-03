using System;
public class Program
{
    public static void Main()
    {
        // Requirment: Write a program that reads a string, converts it to Boolean variable and prints “Yes” if the variable is true and “No” if the variable is false.

        // Example:
        //  Input	Output
        //  True     Yes
        //  False    No

        // Reading input:
        string input = Console.ReadLine();

        // Check if input is boolean value and converting:
        if (Boolean.TryParse(input, out bool converted))
        {
            // Printing output:
            if (converted == true)
            { 
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}