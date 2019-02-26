using System;

public class Program
{
    public static void Main()
    {
        //Define a method Fib(n) that calculates the nth Fibonacci number. 

        int numberInSequence = int.Parse(Console.ReadLine());

        if (numberInSequence > 0 && numberInSequence <= 3)
        {
            Console.WriteLine(numberInSequence);
            Environment.Exit(0);
        }

        FibonnaciSequence(numberInSequence);
    }

    public static void FibonnaciSequence(int numberInSequence)
    {
        int firstNumber = 2;
        int secondNumber = 3;

        for (int indexInSeq = 3; indexInSeq < numberInSequence; indexInSeq++)
        {
            int temporary = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = temporary;
        }

        Console.WriteLine(secondNumber);
    }
}
