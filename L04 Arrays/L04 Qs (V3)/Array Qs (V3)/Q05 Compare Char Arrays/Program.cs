using System;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: 
        // Compare two char arrays lexicographically(letter by letter).
        // Print the them in alphabetical order, each on separate line.

        // Example:
        // Input            Output
        //p e t e r         annie
        // a n n i e        peter

        // Example 2:
        // Input            Ouput
        // a n n i e         an
        // a n              annie
        #endregion

        // Reading input:
        var first = string.Join("", Console.ReadLine().Split(' '));
        var second = string.Join("", Console.ReadLine().Split(' '));;

        // compare them with the method and print depending on the retunred value
        int compared = string.Compare(first, second);
        if (compared <= 0)
        {
            Console.WriteLine(first);
            Console.WriteLine(second);
        }
        else
        {
            Console.WriteLine(second);
            Console.WriteLine(first);
        }
    }
}