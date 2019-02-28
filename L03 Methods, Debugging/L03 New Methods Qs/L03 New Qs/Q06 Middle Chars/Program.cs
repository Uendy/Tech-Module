using System;
public class Program
{
    public static void Main()
    {
        //You will receive a single string. Write a method that prints the middle character. 
        //If the length of the string is even there are two middle characters.

        string input = Console.ReadLine();

        string outPut = MiddleCharFinder(input);

        Console.WriteLine(outPut);
    }

    public static string MiddleCharFinder(string input)
    {
        string output = string.Empty;

        if (input.Length % 2 == 0) // even Length -> 2 middle chars
        {
            int middleCharIndex = input.Length / 2;

            for (int index = middleCharIndex - 1; index < middleCharIndex + 1; index++)
            {
                output += input[index];
            }
        }
        else
        {
            int middleCharIndex = input.Length / 2; 

            output += input[middleCharIndex];
        }

        return output;
    }
}