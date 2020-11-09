using System;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions:
        // Read two arrays of words and find the length of the largest common end (left or right).

        // Example: 
        //              Input	                             Output                      	      Comments
        //  hi php java csharp sql html css js                  3               The largest common end is at the left: hi php java
        // hi php java js softuni nakov java learn    

        #endregion

        // Reading input:
        var firstInput = Console.ReadLine().Split(' ');
        var secondInput = Console.ReadLine().Split(' ');

        // Finding smaller length
        int smallerLength = Math.Min(firstInput.Length, secondInput.Length);

        // Cycling front to back
        int matchingStartCount = 0;
        for (int i = 0; i < smallerLength; i++)
        {
            matchingStartCount = CompareAndIncrament(matchingStartCount, i, firstInput, secondInput);
        }

        // Idea: what if you while them and check their [.length-1] ?

        
        // Cycling beck to front
        int matchingEndCount = 0;
        for (int i = smallerLength - 1; i >= 0; i--)
        {
            // Finding the smaller array 
            if (firstInput.Length >= secondInput.Length)
            {
                int difference = firstInput.Length - secondInput.Length;
                secondInput = new string[] (0 * difference, secondInput)
            }
            else
            {

            }

            matchingEndCount = CompareAndIncrament(matchingEndCount, i, firstInput, secondInput);
        }

        // Finding longest count and Printing Output:
        if (matchingStartCount >= matchingEndCount)
        {
            Console.WriteLine(matchingStartCount);
        }
        else
        {
            Console.WriteLine(matchingEndCount);
        }

    }

    /// Gets the current string from both arrays, then checks to see if they match and incraments count
    public static int CompareAndIncrament(int count, int i, string[] firstInput, string[] secondInput)
    {
        string firstInputString = firstInput[i];
        string secondInputString = secondInput[i];

        bool isMatch = firstInputString == secondInputString;
        if (isMatch)
        {
            count++;
        }

        return count;
    }
}