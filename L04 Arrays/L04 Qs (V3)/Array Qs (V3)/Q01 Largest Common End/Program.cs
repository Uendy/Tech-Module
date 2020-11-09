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

        // Cylcing from front to back:
        int frontCount = 0;
        for (int i = 0; i < firstInput.Length && i < secondInput.Length; i++)
        {
            string firstString = firstInput[i];
            string secondString = secondInput[i];

            frontCount = CheckStrings(frontCount, firstString, secondString);
        }

        // Cycling from back to front:
        int backwardsCount = 0;
        for (int j = 0; j < firstInput.Length && j < secondInput.Length; j++) 
        {
            string firstString = firstInput[firstInput.Length - 1 - j]; 
            string secondString = secondInput[secondInput.Length - 1 - j];

            if (firstString == secondString)
            {
                backwardsCount++;
            }
        }

        // Printing output:
        Console.WriteLine(Math.Max(frontCount, backwardsCount));
    }

    /// Checking both string to see if they are equal and incramenting count if needed
    public static int CheckStrings(int count, string firstString, string secondString)
    {
        if(firstString == secondString)
        {
            count++;
        }

        return count;
    }
}