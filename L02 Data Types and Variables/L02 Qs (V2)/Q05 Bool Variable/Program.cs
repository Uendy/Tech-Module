using System;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a string, converts it to Boolean variable and prints “Yes” if the variable is true and “No” if the variable is false.
        bool input = bool.Parse(Console.ReadLine().ToLower());

        switch (input)
        {
            case true:
                Console.WriteLine("Yes");
                break;
            case false:
                Console.WriteLine("No");
                break;
        }
    }
}

