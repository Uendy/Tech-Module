using System;

public class Program
{
    public static void Main()
    {
        //Write a program that safely compares floating - point numbers(double) with precision eps = 0.000001.
        //Note that we cannot directly compare two floating - point numbers a and b by a== b because of the nature of the floating - point arithmetic.
        //Therefore, we assume two numbers are equal if they are more closely to each other than some fixed constant eps. 

        double eps = 0.000001;
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());

        double difference = Math.Abs(firstNumber - secondNumber);

        if (difference > eps)
        {
            Console.WriteLine("False");
        }
        else
        {
            Console.WriteLine("True");
        }
    }
}
