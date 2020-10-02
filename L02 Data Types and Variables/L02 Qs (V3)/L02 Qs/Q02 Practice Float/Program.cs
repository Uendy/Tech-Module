using System;
public class Program
{
    public static void Main()
    {
        // Instructions:
        // Create a new C# project and create a program that assigns floating point values to variables. Be sure that each value is stored in the correct variable type (try to find the most suitable variable type in order to save memory). Finally, you need to print all variables to the console.

        // Ex input: 
        // 3.141592653589793238
        // 1.60217657
        // 7.8184261974584555216535342341

        // Reading decimal numbers
        double doubleNum = double.Parse(Console.ReadLine());
        float floatNum = float.Parse(Console.ReadLine());
        decimal decimalNum = decimal.Parse(Console.ReadLine());



        // Printing decimal numbers
        Console.WriteLine(doubleNum);
        Console.WriteLine(floatNum);
        Console.WriteLine(decimalNum);
    }
}