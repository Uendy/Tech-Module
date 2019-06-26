using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        //You are given two lines - the first one can be a really big number (0 to 1050). 
        //The second one will be a single digit number (0 to 9). You must display the product of these numbers.
        //Note: do not use the BigInteger or BigDecimal classes for solving this problem.

        var firstNumber = Console.ReadLine();
        int secondNumber = int.Parse(Console.ReadLine());

        if (firstNumber == "0" || secondNumber == 0 || firstNumber == string.Empty)
        {
            Console.WriteLine(0);
            return;
        }

        var sum = new List<int>();
        for (int i = 0; i < firstNumber.Length; i++)
        {
            sum.Add(0);
        }

        var firstNumArray = firstNumber.ToCharArray();

        var carryOver = 0;
        for (int index = firstNumArray.Count() - 1; index >= 0; index--)
        {
            var actualFirstNum = firstNumArray[index] - '0';
            var currentNumber = actualFirstNum * secondNumber + carryOver;
            if (currentNumber > 9)
            {
                carryOver = currentNumber / 10;
                currentNumber = currentNumber % 10;
                if (index == 0)
                {
                    sum[index] = currentNumber;
                    sum.Insert(0, carryOver);
                }
                else
                {
                    sum[index] = currentNumber;
                }
            }
            else
            {
                sum[index] = currentNumber;
                carryOver = 0;
            }

        }

        var sb = new StringBuilder();
        foreach (var number in sum)
        {
            sb.Append(number);
        }
        var output = sb.ToString();
        Console.WriteLine(output.TrimStart('0'));
    }
}