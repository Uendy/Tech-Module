using System;
public class Program
{
    public static void Main()
    {
        //Read two integer numbers. Calculate factorial of each number. /// GetFactorial()
        //Divide the first result by the second and print the division formatted to the second decimal point. ///DivideFactorials()

        int firstNum = int.Parse(Console.ReadLine());
        double firstNumFactorial = GetFactorial(firstNum);

        firstNum = int.Parse(Console.ReadLine());
        double secondNumFactorial = GetFactorial(firstNum);

        double outPutNum = firstNumFactorial / secondNumFactorial;

        Console.WriteLine($"{outPutNum:f2}");
    }

    public static double GetFactorial(int firstNum)
    {
        double sum = firstNum;

        for (int index = firstNum - 1; index > 1; index--)
        {
            sum *= index;
        }

        return sum;
    }
}