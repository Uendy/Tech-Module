using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Create a method GetMin(int a, int b), that returns maximal of two numbers. Write a program that reads three numbers from the console and prints the biggest of them. Use the GetMax(…) method you just created.

        // Examples:
        // Input  Output
        //  1       3
        //  2
        //  3    

        // Reading inputs
        int inputOne = int.Parse(Console.ReadLine());
        int inputTwo = int.Parse(Console.ReadLine());
        int inputThree = int.Parse(Console.ReadLine());

        Console.WriteLine(GetMax(inputOne, inputTwo, inputThree));
    }
    
    /// returns the biggest of 3 inputs:
    public static int GetMax(int inputOne, int inputTwo, int inputThree) 
    {
        int biggest = Math.Max(inputOne, inputTwo); 
        biggest = Math.Max(biggest, inputThree);

        return biggest;
    }
}