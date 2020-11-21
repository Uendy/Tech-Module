using System;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a program that creates an array containing all letters from the alphabet (a-z). Read a lowercase word from the console and print the index of each of its letters in the letters array.

        // Example: 
        // Input        Output
        //  abcz	
        //              a -> 0
        //              b-> 1
        //              c-> 2
        //              z-> 25
        #endregion

        // Reading input:
        var input = Console.ReadLine().ToLower().ToCharArray();

        // Cycle, Get number and Print:
        for (int index = 0; index < input.Length; index++)
        {
            char current = input[index];
            var asNumber = current - 'a';
            Console.WriteLine($"{current} -> {asNumber}");
        }
    }
}