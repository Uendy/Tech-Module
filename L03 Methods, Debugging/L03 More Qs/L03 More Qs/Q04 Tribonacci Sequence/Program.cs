using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // You are given a number num. Write a program that prints num numbers from the Tribonacci sequence, each on a new line, starting from 1.
        //The input comes as a parameter named num.The value num will always be positive integer.

        int num = int.Parse(Console.ReadLine());

        int firstNum = 1;
        int secondNum = 1;
        int thirdNum = 2;

        if (num == 0)
        {
            Console.WriteLine(0);
        }
        else if (num == 1)
        {
            Console.WriteLine(firstNum);
        }
        else if (num == 2)
        {
            Console.WriteLine($"{firstNum} {secondNum}");
        }
        else if (num == 3)
        {
            Console.WriteLine($"{firstNum} {secondNum} {thirdNum}");
        }
        else
        {
            var listOfSequence = new List<int>();
            listOfSequence.Add(firstNum);
            listOfSequence.Add(secondNum);
            listOfSequence.Add(thirdNum);

            Tribonacci(num, firstNum, secondNum, thirdNum, listOfSequence);

            string output = string.Join(" ", listOfSequence);
            Console.WriteLine(output);
        }
            
    }

    static List<int> Tribonacci(int num, int firstNum, int secondNum, int thirdNum, List<int> listOfSequence)
    { ///In the "Tribonacci" sequence, every number is formed by the sum of the previous 3.

        for (int indexOfSequence = 3; indexOfSequence < num; indexOfSequence++)
        {
            int newNumber = firstNum + secondNum + thirdNum;
            listOfSequence.Add(newNumber);
            firstNum = secondNum;
            secondNum = thirdNum;
            thirdNum = newNumber;
        }

        return listOfSequence;
    }
}
