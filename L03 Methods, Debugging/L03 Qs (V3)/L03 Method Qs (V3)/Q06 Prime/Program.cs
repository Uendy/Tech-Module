using System;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a Boolean method IsPrime(n) that check whether a given integer number n is prime. 

        // Example:
        // Input                   Output
        //n	IsPrime(n)
        //    0                     false
        //    1                     false
        //    2                     true
        //    3                     true
        //    4                     false
        //    5                     true
        //    323                   false
        //    337                   true
        //    6737626471            true
        //    117342557809          false
        #endregion

        // Reading input:
        long input = long.Parse(Console.ReadLine());
        bool isPrime = PrimeChecker(input);

        // Printing output:
        Console.WriteLine(isPrime);
    }

    /// Method to check if input is prime
    private static bool PrimeChecker(long input)
    {
        if (input < 2) // need to see if its lower than 2 as {0, 1} are not checkable and not prime
        {
            return false;
        }
        else
        {
            bool isPrime = true;
            for (int i = 2; i <= Math.Floor(Math.Sqrt(input)); i++) // cycles through 2 -> sqrt(N) (any higher num is not necessary to check)
            {
                if (input % i == 0) // see if the num is divisible
                {
                    isPrime = false; // No need to cylce more
                    if (isPrime == false)
                    {
                        return isPrime;
                    }
                }
            }

            return isPrime;
        }
    }
}