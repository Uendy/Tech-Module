using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001. Note that we cannot directly compare two floating-point numbers a and b by a==b because of the nature of the floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely to each other than some fixed constant eps. Examples:

        // Example:
        //   Number a	        Number b	    Equal (with precision eps=0.000001)	                            Explanation
        //    5.3                6.01                      False                                   The difference of 0.71 is too big (> eps)
        //  5.00000001          5.00000003                 True                                         The difference 0.00000002 < eps

        // Reading input:
        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());

        // Comparing and printing:
        double eps = 0.000001;
        double diff = Math.Abs(firstNum - secondNum);

        bool closeEnough = diff < eps;

        if (closeEnough)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}