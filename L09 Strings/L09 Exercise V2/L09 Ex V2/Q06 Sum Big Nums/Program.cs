using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        //You are given two lines - each can be a really big number (0 to 1050).
        //You must display the sum of these numbers.
        //Note: do not use the BigInteger or BigDecimal classes for solving this problem.

        var firstNumber = Console.ReadLine();
        var secondNumber = Console.ReadLine();

        // if it goes over 10 we [i+1] = 1 if (already == something, add)
        var listOfDigits = new List<int>();

        var bigger = Math.Max(firstNumber.Length, secondNumber.Length);
        var smaller = Math.Min(firstNumber.Length, secondNumber.Length);

        for (int index = 0; index < bigger; index++)
        {
            listOfDigits.Add(0);
        }

        if (bigger == smaller) // equalLength
        {
            var longer = firstNumber;
            var shorter = secondNumber;

            DiffLengthEqualiser(longer, shorter, listOfDigits);
        }
        else if (firstNumber.Length > secondNumber.Length)
        {
            var longer = firstNumber;
            var shorter = secondNumber;

            DiffLengthEqualiser(longer, shorter, listOfDigits);
        }
        else // 2nd > 1st
        {
            var longer = secondNumber;
            var shorter = firstNumber;

            DiffLengthEqualiser(longer, shorter, listOfDigits);
        }

    }

    static void DiffLengthEqualiser(string longer, string shorter, List<int> listOfDigits)////equate lengths
    {
        var shorterElongated = shorter.PadLeft(longer.Length, '0'); 

        SameLengthSummer(longer, shorterElongated, listOfDigits);
    }

    static void SameLengthSummer(string longer, string shorterElongated, List<int> listOfDigits)
    {

        var firstNumReversed = longer.ToCharArray().Reverse().ToArray();
        var secondNumReversed = shorterElongated.ToCharArray().Reverse().ToArray();

        bool carryOneOver = false;
        for (int index = 0; index < longer.Length; index++)
        {
            var firstNumberAsInt = firstNumReversed[index] - '0';
            var secondNumberAsInt = secondNumReversed[index] - '0';

            var currentNumber = firstNumberAsInt + secondNumberAsInt;

            if (carryOneOver == true)
            {
                currentNumber++;
            }

            bool aboveNine = currentNumber >= 10; // you have to carryOneOver
            if (aboveNine == true)
            {
                currentNumber -= 10;
                if (index + 1 != longer.Length) //carryOneOver On Next Index
                {
                    listOfDigits[index] = currentNumber;
                    carryOneOver = true;
                    continue;
                }
                else // next number is outside of current sb
                {
                    listOfDigits[index] = currentNumber;
                    listOfDigits.Reverse(); // when you get 99 + 98 -> 179 so you reverse the 7 and 9 to get 197
                    listOfDigits.Insert(0, 1);
                    continue;
                }
            }

            listOfDigits[index] += currentNumber;
            carryOneOver = false;
        }
        if (listOfDigits.Count == longer.Length)
        {
            listOfDigits.Reverse();
        }
        var sb = new StringBuilder();

        foreach (var number in listOfDigits)
        {
            sb.Append(number);
        }

        var output = sb.ToString();

        Console.WriteLine(output.TrimStart('0'));

        Environment.Exit(0);
    }
}