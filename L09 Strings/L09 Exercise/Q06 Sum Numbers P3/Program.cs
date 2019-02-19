using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var firstNumber = Console.ReadLine();
        var secondNumber = Console.ReadLine();

        var sb = new StringBuilder();
        // if it goes over 10 we [i+1] = 1 if (already == something, add)
        //var listOfDigits = new List<int>();

        var bigger = Math.Max(firstNumber.Length, secondNumber.Length);
        var smaller = Math.Min(firstNumber.Length, secondNumber.Length);

        for (int index = 0; index < bigger; index++)
        {
            sb.Append(0);
            //listOfDigits[index] = 0;
        }

        if (bigger == smaller) // equalLength
        {
            var longer = firstNumber;
            var shorter = secondNumber;

            DiffLengthEqualiser(longer, shorter, sb);
        }
        else if (firstNumber.Length > secondNumber.Length)
        {
            var longer = firstNumber;
            var shorter = secondNumber;

            DiffLengthEqualiser(longer, shorter, sb);
        }
        else // 2nd > 1st
        {
            var longer = secondNumber;
            var shorter = firstNumber;

            DiffLengthEqualiser(longer, shorter, sb);
        }
    }

    static void DiffLengthEqualiser(string longer, string shorter, StringBuilder sb)
    {

        var diffInLength = longer.Length - shorter.Length;
        var inFrontNumber = longer.Take(diffInLength).ToArray();//.Reverse(); // need em backwards

        //var longerShortened = longer.Skip(diffInLength).ToString();
        var shorterElongated = shorter.PadLeft(longer.Length, '0'); // smarter?

        SameLengthSummer(longer, shorterElongated, sb);
    }

    static void SameLengthSummer(string longer, string shorterElongated, StringBuilder sb)
    {

        var firstNumReversed = longer.ToCharArray().Reverse().ToArray();
        var secondNumReversed = shorterElongated.ToCharArray().Reverse().ToArray();

        //bool carryOneOver = false;
        for (int index = 0; index < longer.Length; index++)
        {
            var firstNumberAsInt = firstNumReversed[index] - '0';
            var secondNumberAsInt = secondNumReversed[index] - '0';

            var currentNumber = firstNumberAsInt + secondNumberAsInt;

            bool aboveNine = currentNumber >= 10; // you have to carryOneOver
            if (aboveNine == true)
            {
                currentNumber -= 10;
                if (index + 1 != longer.Length) //carryOneOver On Next Index
                {
                   sb = sb.Replace(sb[index + 1].ToString(), currentNumber.ToString());//+= (char)('0' - currentNumber);
                }
                else // next number is outside of current sb
                {
                    sb.Append(1);
                }
            }

            sb = sb.Replace(sb.ToString(), currentNumber.ToString(), index);// = (char)('0' - currentNumber); // this always takes care of it
        }

        var output = sb.ToString(); // GOTTA REVERSE IT AT THE END
        Console.WriteLine(output);

        Environment.Exit(0);
    }
}
