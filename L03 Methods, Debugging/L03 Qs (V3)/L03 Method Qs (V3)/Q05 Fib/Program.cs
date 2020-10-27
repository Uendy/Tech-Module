using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Define a method Fib(n) that calculates the nth Fibonacci number. Examples:
        // Example:
        // Input    Output:
        //  n	    Fib(n)
        //  0         1
        //  1         1
        //  2         2
        //  3         3
        //  4         5
        //  5         8
        //  6         13
        //  11        144
        //  25        121393

        // Reading input:
        int n = int.Parse(Console.ReadLine());

        // Setting starting nums 
        int numOne = 0;
        int numTwo = 1;

        for (int i = 0; i <= n; i++) // cycling n times
        {
            var nums = new int[2]; // making a place to hold the values
            nums = Fibonacci(numOne, numTwo); 

            numOne = nums[0]; // unpacking them
            numTwo = nums[1];
        }

        // Printing output:
        Console.WriteLine(numOne);
    }

    /// Method that fib sequences the numbers
    private static int[] Fibonacci(int numOne, int numTwo)
    {
        int numMiddle = numOne; // holds new lower value
        numOne = numOne + numTwo;
        numTwo = numMiddle;
        
        return new int[] { numOne, numTwo };
    }
}