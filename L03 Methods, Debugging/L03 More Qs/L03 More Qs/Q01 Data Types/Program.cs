using System;

public class Program
{
    public static void Main()
    {
        //Write a program that, depending on the first line of the input, reads an int, double or string.
        //•	If the data type is int, multiply the number by 2.
        //•	If the data type is real, multiply the number by 1.5 and format it to the second decimal point.
        //•	If the data type is string, surround the input with "$".
        //Print the result on the console.


        string dataType = Console.ReadLine();

        switch (dataType)
        {
            case "int":
                int inputNumber = int.Parse(Console.ReadLine());
                Console.WriteLine(IntModifier(inputNumber));
                break;

            case "real":
                double inputDecimal = double.Parse(Console.ReadLine());
                inputDecimal = DoubleModifier(inputDecimal);
                inputDecimal.ToString();
                Console.WriteLine($"{inputDecimal:f2}");
                break;

            case "string":
                string inputString = Console.ReadLine();
                Console.WriteLine(StringModifier(inputString));
                break;
        }
    }

    static int IntModifier(int inputNumber)
    {
        return inputNumber * 2;
    }

    static double DoubleModifier (double inputDecimal)
    {
        inputDecimal *= 1.5;
        return Math.Round(inputDecimal, 2);
    }

    static string StringModifier(string inputString)
    {
        inputString = '$' + inputString;
        inputString = inputString + '$';
        return inputString;
    }
}
