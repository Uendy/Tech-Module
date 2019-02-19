using System;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var firstNumber = Console.ReadLine();
        var secondNumber = Console.ReadLine();

        var sb = new StringBuilder();

        var firstNumberLength = firstNumber.Length;
        var secondNumberLength = secondNumber.Length;

        var longerNumber = string.Empty;
        var shorterNumber = string.Empty;

        if (firstNumberLength > secondNumberLength)
        {
            longerNumber = firstNumber;
            shorterNumber = secondNumber;
            diffSizedNumberSummed(longerNumber, shorterNumber, sb);

            var outputString = sb.ToString();
            var outputStringAsCharArray = outputString.ToCharArray().Reverse();
            var output = string.Join(string.Empty, outputStringAsCharArray);

            Console.WriteLine(output);
        }
        else if (secondNumberLength > firstNumberLength)
        {
            longerNumber = secondNumber;
            shorterNumber = firstNumber;
            diffSizedNumberSummed(longerNumber, shorterNumber, sb);

            var outputString = sb.ToString();
            var outputStringAsCharArray = outputString.ToCharArray().Reverse();
            var output = string.Join(string.Empty, outputStringAsCharArray);

            Console.WriteLine(output);
        }
        else
        {
            var longerNumberAsCharArray = firstNumber.ToCharArray();
            var shorterNumberAsCharArray = secondNumber.ToCharArray();
            SumEqualLengthNumber(longerNumberAsCharArray, shorterNumberAsCharArray, sb);

            var outputString = sb.ToString();
            var outputStringAsCharArray = outputString.ToCharArray().Reverse();
            var output = string.Join(string.Empty, outputStringAsCharArray);

            Console.WriteLine(output);
        }
    }

    public static void diffSizedNumberSummed(string longerNumber, string shorterNumber, StringBuilder sb)
    {
        var longerNumberAsCharArray = longerNumber.ToCharArray();
        var shorterNumberAsCharArray = shorterNumber.ToCharArray();
        var diffInLength = longerNumberAsCharArray.Length - shorterNumberAsCharArray.Length;
        var numbersInFront = longerNumberAsCharArray.Take(diffInLength).ToArray().Reverse().ToArray();
        longerNumberAsCharArray = longerNumberAsCharArray
            .Skip(diffInLength)
            .Take(shorterNumberAsCharArray.Length)
            .ToArray();

        bool carryOneOver = false;

        SumEqualLengthNumber(longerNumberAsCharArray, shorterNumberAsCharArray, sb);
        //if (sb.ToString().Count() > longerNumberAsCharArray.ToString().Count())
        //{
        //    carryOneOver = true;
        //}

        foreach (var number in numbersInFront)
        {
            if (carryOneOver == true) // a safety measure if last sum in above loop is >=10
            {
                sb.Append((number - '0') + 1);
                carryOneOver = false;
                continue;
            }
            sb.Append(number);
        }

    }

    public static void SumEqualLengthNumber(char[] longerNumberAsCharArray, char[] shorterNumberAsCharArray, StringBuilder sb)
    {
        bool carryOneOver = false; // I would have called a method in a method and it would have handled all 3 cases to elegantly
        //but this bool is not found in the case where they are evenLength (else) so I don't know how to 
        for (int index = shorterNumberAsCharArray.Length - 1; index >= 0; index--)
        {
            var currentDigit = (longerNumberAsCharArray[index] - '0') + (shorterNumberAsCharArray[index] - '0');
            if (carryOneOver == true)
            {
                currentDigit++;
            }

            if (currentDigit >= 10)
            {
                currentDigit -= 10;
                sb.Append(currentDigit);
                carryOneOver = true;
                //if (index == 0) // when it has to carry one over but the loop is over
                //{
                //    sb.Append(0);  // my attempt to fix it but no luck
                //}
                continue;
            }

            sb.Append(currentDigit);
            carryOneOver = false;
        }
    }
}
