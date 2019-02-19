using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var firstNum = Console.ReadLine();
        var secondNum = Console.ReadLine();

        var maxLength = Math.Max(firstNum.Length, secondNum.Length); // equalizing their length
        var firstNumPadded = firstNum.PadLeft(maxLength, '0');
        var secondNumPadded = secondNum.PadLeft(maxLength, '0');

        var listOfNumbers = new List<int>(maxLength);
        for (int index = 0; index < maxLength; index++)
        {
            listOfNumbers.Add(0);
        }

        SumNumbers(firstNumPadded, secondNumPadded, listOfNumbers);
    }

    static void SumNumbers(string firstNumPadded, string secondNumPadded, List<int> listOfNumbers) {

        var firstDigitArray = firstNumPadded.ToCharArray();
        var secondDigitArray = secondNumPadded.ToCharArray();

        bool carryOver = false;                        // carryOver = 0
        for (int index = firstDigitArray.Count() - 1; index >= 0; index--)
        {
            var firstDigit = firstDigitArray[index] - '0';
            var secondDigit = secondDigitArray[index] - '0';

            var currentDigit = firstDigit + secondDigit; // + carryOver 
            if (carryOver == true)
            {
                currentDigit++;
            }

            if (currentDigit >= 10)
            {
                carryOver = true;                       // carryOver = 1
                listOfNumbers[index] = currentDigit - 10;
                continue;
            }
            else                                        // carryOver = 0 
            {
                listOfNumbers[index] = currentDigit;
            }
            carryOver = false;
        }
        if (carryOver == true)
        {
            listOfNumbers.Insert(0, 1);
        }

        var sb = new StringBuilder();
        foreach (var number in listOfNumbers) 
        {
            sb.Append(number);
        }

        var output = sb.ToString();
        Console.WriteLine(output.TrimStart('0')); // you had to trim start to get 100% and not 80%
        Environment.Exit(0);
    }
}
