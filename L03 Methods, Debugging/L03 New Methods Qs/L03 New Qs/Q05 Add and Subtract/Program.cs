using System;

public class Program
{
    public static void Main()
    {
        //You will receive 3 integers.
        //Write a method Sum to get the sum of the first two integers and 
        //Subtract method that subtracts the third integer from the result from the Sum method. 

        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());

        int firstSum = Sum(firstNum, secondNum);

        int secondSum = Subtract(firstSum, thirdNum);

        Console.WriteLine(secondSum);
    }

    public static int Sum(int firstNum, int secondNum)
    {
        int sum = 0;

        sum += firstNum + secondNum;

        return sum;
    }

    public static int Subtract(int firstSum, int thirdNum)
    {
        int sum = 0;

        sum += firstSum - thirdNum;

        return sum;
    }
}