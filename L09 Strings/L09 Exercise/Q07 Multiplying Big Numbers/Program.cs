using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
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
