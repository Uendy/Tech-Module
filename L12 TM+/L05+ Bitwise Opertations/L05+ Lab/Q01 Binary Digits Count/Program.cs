using System;
public class Program
{
    public static void Main()
    {
        //You are given a positive integer number and one binary digit B(0 or 1). 
        //Your task is to write a program that finds the number of binary digits(B) in a number.
        //Examples
        //Input   Output     Comments
        //20
        //0         3       20-> 10100

        //15
        //1         4         15-> 1111

        //10
        //0         2         10-> 1010


        int input = int.Parse(Console.ReadLine());
        int bit = int.Parse(Console.ReadLine());

        int total = 0;
        if (bit == 0)
        {
            while (input > 1)
            {
                bool anotherZero = input % 2 == 0;
                if (anotherZero)
                {
                    total++;
                }
                input /= 2;
            }
        }
        else //bit == 1
        {
            while (input != 0)
            {
                bool anotherOne = input % 2 != 0;
                if (anotherOne)
                {
                    total++;
                }
                input /= 2;
            }
        }

        Console.WriteLine(total);
    }
}