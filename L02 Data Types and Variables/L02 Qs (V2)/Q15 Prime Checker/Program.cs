using System;

public class Program
{
    public static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        for (int currentNumber = 3; currentNumber <= input; currentNumber++)
        {
            bool isPrime = true;

            for (int primeChecker = 2; primeChecker < currentNumber; primeChecker++)
            {
                if (currentNumber % primeChecker == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine($"{currentNumber} is prime -> {isPrime}");

        }
    }
}
