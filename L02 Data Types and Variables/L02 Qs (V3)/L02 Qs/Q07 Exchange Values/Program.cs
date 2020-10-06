using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values by using some programming logic. Print the variable values before and after the exchange, as shown below:

        // Example:
        // Input    Output
        //  5       Before: 
        //  10       a = 5
        //           b = 10
        //          After:
        //           a = 10
        //           b = 5

        // Reading variables:
        int firstVar = int.Parse(Console.ReadLine());
        int secondVar = int.Parse(Console.ReadLine());

        // Exchanging values:
        int intermediary = firstVar;
        firstVar = secondVar;
        secondVar = intermediary;

        // Printing values:
        Console.WriteLine(firstVar);
        Console.WriteLine(secondVar);
    }
}