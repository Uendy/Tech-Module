using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Write a method that returns the English name of the last digit of a given number. Write a program that reads an integer and prints the returned value from this method.

        // Examples
        // Input        Output      
        //  1024         four        
        //  512          two

        // Reading input:
        int input = int.Parse(Console.ReadLine());
        int lastDigit = input % 10;
        Console.WriteLine(ReturnLastDigitAsString(lastDigit));
    }

    /// Returns the last digit as a word (string)
    public static string ReturnLastDigitAsString(int input)
    {
        switch (input)
        {
            case 0:
                return "zero";

            case 1:
                return "one";

            case 2:
                return "two";

            case 3:
                return "three";

            case 4:
                return "four";

            case 5:
                return "five";

            case 6:
                return "six";

            case 7:
                return "seven";

            case 8:
                return "eight";

            case 9:
                return "nine";
            default:
                return null;
        }
    }
}