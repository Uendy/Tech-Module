using System;

public class Program
{
    public static void Main()
    {
        //https://judge.softuni.bg/Contests/206/Data-Types-and-Variables-Exercises

        //Create a new C# project and create a program that assigns integer values to variables. 
        //Be sure that each value is stored in the correct variable type (try to find the most suitable variable type in order to save memory).
        //Finally, you need to print all variables to the console.

        //-100
        //128
        //-3540
        //64876
        //2147483648
        //-1141583228
        //-1223372036854775808

        sbyte firstNumber = sbyte.Parse(Console.ReadLine());
        byte secondNumber = byte.Parse(Console.ReadLine());
        short thirdNumber = short.Parse(Console.ReadLine());
        ushort forthNumber = ushort.Parse(Console.ReadLine());
        uint fifthNumber = uint.Parse(Console.ReadLine());
        int sixthNumber = int.Parse(Console.ReadLine());
        long seventhNumber = long.Parse(Console.ReadLine());

        Console.WriteLine(firstNumber);
        Console.WriteLine(secondNumber);
        Console.WriteLine(thirdNumber);
        Console.WriteLine(forthNumber);
        Console.WriteLine(fifthNumber);
        Console.WriteLine(sixthNumber);
        Console.WriteLine(seventhNumber);

    }
}

